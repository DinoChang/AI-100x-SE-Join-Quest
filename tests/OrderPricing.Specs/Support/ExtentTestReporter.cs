using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Collections.Concurrent;

namespace OrderPricing.Specs.Support;

public class ExtentTestReporter
{
    private static ExtentReports? _extentReports;
    private static ExtentSparkReporter? _sparkReporter;
    private static readonly ConcurrentDictionary<string, ExtentTest> _features = new();
    private static readonly ConcurrentDictionary<string, ExtentTest> _scenarios = new();
    
    public static ExtentReports Instance => _extentReports ??= CreateReporter();

    private static ExtentReports CreateReporter()
    {
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "TestResults", $"ExtentReport_{timestamp}.html");
        
        // 確保目錄存在
        Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
        
        _sparkReporter = new ExtentSparkReporter(reportPath);
        
        // 配置報告樣式和資訊
        _sparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
        _sparkReporter.Config.DocumentTitle = "OrderPricing BDD Test Report";
        _sparkReporter.Config.ReportName = "SpecFlow ExtentReports";
        _sparkReporter.Config.Encoding = "UTF-8";
        
        var extent = new ExtentReports();
        extent.AttachReporter(_sparkReporter);
        
        // 設定系統資訊
        extent.AddSystemInfo("Environment", "Development");
        extent.AddSystemInfo("User", Environment.UserName);
        extent.AddSystemInfo("OS", Environment.OSVersion.ToString());
        extent.AddSystemInfo(".NET Version", Environment.Version.ToString());
        extent.AddSystemInfo("Machine", Environment.MachineName);
        
        return extent;
    }

    public static ExtentTest CreateFeature(string featureKey, string featureName, string? featureDescription = null)
    {
        return _features.GetOrAdd(featureKey, _ => 
            Instance.CreateTest(featureName, featureDescription ?? string.Empty));
    }

    public static ExtentTest CreateScenario(string featureKey, string scenarioKey, string scenarioName, string? scenarioDescription = null)
    {
        if (!_features.TryGetValue(featureKey, out var feature))
            throw new InvalidOperationException($"Feature with key '{featureKey}' must be created before creating a scenario");
            
        return _scenarios.GetOrAdd(scenarioKey, _ => 
            feature.CreateNode(scenarioName, scenarioDescription ?? string.Empty));
    }

    public static void LogStep(string scenarioKey, Status status, string stepText, string? details = null)
    {
        if (!_scenarios.TryGetValue(scenarioKey, out var scenario))
            throw new InvalidOperationException($"Scenario with key '{scenarioKey}' must be created before logging steps");
            
        scenario.Log(status, stepText + (string.IsNullOrEmpty(details) ? "" : $": {details}"));
    }

    public static void AddTag(string scenarioKey, string tag)
    {
        if (_scenarios.TryGetValue(scenarioKey, out var scenario))
        {
            scenario.AssignCategory(tag);
        }
    }

    public static void LogException(string scenarioKey, Exception exception)
    {
        if (_scenarios.TryGetValue(scenarioKey, out var scenario))
        {
            scenario.Log(Status.Fail, exception.ToString());
        }
    }

    public static void FlushReport()
    {
        _extentReports?.Flush();
        // ExtentSparkReporter 在 5.x 版本中不需要手動 Flush
    }

    public static void CleanUp()
    {
        _scenarios.Clear();
        _features.Clear();
        _extentReports?.Flush();
        _extentReports = null;
        _sparkReporter = null;
    }
}