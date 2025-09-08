using AventStack.ExtentReports;
using OrderPricing.Specs.Support;
using TechTalk.SpecFlow;

namespace OrderPricing.Specs.Hooks;

[Binding]
public class ExtentReportHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
{
    private readonly ScenarioContext _scenarioContext = scenarioContext;
    private readonly FeatureContext _featureContext = featureContext;

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // ExtentReports 會在第一次存取 Instance 時自動初始化
        Console.WriteLine("ExtentReports initialized");
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        var featureName = featureContext.FeatureInfo.Title;
        var featureDescription = featureContext.FeatureInfo.Description;
        var featureKey = $"Feature_{featureName}_{Thread.CurrentThread.ManagedThreadId}";
        
        ExtentTestReporter.CreateFeature(featureKey, featureName, featureDescription);
        featureContext["FeatureKey"] = featureKey;
        Console.WriteLine($"Feature started: {featureName} (Key: {featureKey})");
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var featureKey = _featureContext["FeatureKey"].ToString()!;
        var scenarioName = _scenarioContext.ScenarioInfo.Title;
        var scenarioDescription = _scenarioContext.ScenarioInfo.Description;
        var scenarioKey = $"Scenario_{scenarioName}_{Thread.CurrentThread.ManagedThreadId}_{Guid.NewGuid():N}";
        
        ExtentTestReporter.CreateScenario(featureKey, scenarioKey, scenarioName, scenarioDescription);
        _scenarioContext["ScenarioKey"] = scenarioKey;
        
        // 添加 Tags
        foreach (var tag in _scenarioContext.ScenarioInfo.Tags)
        {
            ExtentTestReporter.AddTag(scenarioKey, tag);
        }
        
        Console.WriteLine($"Scenario started: {scenarioName} (Key: {scenarioKey})");
    }

    [AfterStep]
    public void AfterStep()
    {
        var scenarioKey = _scenarioContext["ScenarioKey"].ToString()!;
        var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        var stepText = $"{stepType} {_scenarioContext.StepContext.StepInfo.Text}";
        
        if (_scenarioContext.TestError != null)
        {
            ExtentTestReporter.LogStep(scenarioKey, Status.Fail, stepText, _scenarioContext.TestError.Message);
            ExtentTestReporter.LogException(scenarioKey, _scenarioContext.TestError);
        }
        else
        {
            ExtentTestReporter.LogStep(scenarioKey, Status.Pass, stepText);
        }
    }

    [AfterScenario]
    public void AfterScenario()
    {
        var scenarioKey = _scenarioContext["ScenarioKey"].ToString()!;
        var scenarioName = _scenarioContext.ScenarioInfo.Title;
        
        if (_scenarioContext.TestError != null)
        {
            ExtentTestReporter.LogStep(scenarioKey, Status.Fail, $"Scenario: {scenarioName}", 
                $"Failed with error: {_scenarioContext.TestError.Message}");
            Console.WriteLine($"Scenario failed: {scenarioName}");
        }
        else
        {
            ExtentTestReporter.LogStep(scenarioKey, Status.Pass, $"Scenario: {scenarioName}", "Scenario completed successfully");
            Console.WriteLine($"Scenario passed: {scenarioName}");
        }
    }

    [AfterFeature]
    public static void AfterFeature(FeatureContext featureContext)
    {
        var featureName = featureContext.FeatureInfo.Title;
        Console.WriteLine($"Feature completed: {featureName}");
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        ExtentTestReporter.FlushReport();
        
        // 找到最新生成的報告檔案
        var testResultsDir = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
        if (Directory.Exists(testResultsDir))
        {
            var reportFiles = Directory.GetFiles(testResultsDir, "ExtentReport_*.html");
            if (reportFiles.Length > 0)
            {
                var latestReport = reportFiles.OrderByDescending(File.GetCreationTime).First();
                Console.WriteLine($"ExtentReports report generated: {latestReport}");
                
                // 嘗試在瀏覽器中開啟報告（僅在開發環境）
                if (Environment.GetEnvironmentVariable("CI") == null)
                {
                    try
                    {
                        if (OperatingSystem.IsWindows())
                        {
                            System.Diagnostics.Process.Start("cmd", $"/c start {latestReport}");
                        }
                        else if (OperatingSystem.IsMacOS())
                        {
                            System.Diagnostics.Process.Start("open", latestReport);
                        }
                        else if (OperatingSystem.IsLinux())
                        {
                            System.Diagnostics.Process.Start("xdg-open", latestReport);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Could not open report automatically: {ex.Message}");
                    }
                }
            }
        }
        
        ExtentTestReporter.CleanUp();
        Console.WriteLine("ExtentReports completed and cleaned up");
    }
}