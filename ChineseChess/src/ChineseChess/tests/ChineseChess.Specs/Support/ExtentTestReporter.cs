namespace ChineseChess.Specs.Support;

// No-op shim for legacy ExtentReports integration. Keeps method signatures so
// existing hooks compile without referencing AventStack.
public static class ExtentTestReporter
{
    public static void CreateFeature(string featureKey, string featureName, string? featureDescription = null) { }
    public static void CreateScenario(string featureKey, string scenarioKey, string scenarioName, string? scenarioDescription = null) { }
    public static void LogStep(string scenarioKey, object status, string stepText, string? details = null) { }
    public static void AddTag(string scenarioKey, string tag) { }
    public static void LogException(string scenarioKey, Exception exception) { }
    public static void FlushReport() { }
    public static void CleanUp() { }
}