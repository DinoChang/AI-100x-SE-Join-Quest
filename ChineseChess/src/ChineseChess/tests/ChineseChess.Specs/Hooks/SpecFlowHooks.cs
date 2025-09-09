using TechTalk.SpecFlow;

namespace ChineseChess.Specs.Hooks;

[Binding]
public sealed class SpecFlowHooks
{
    private readonly ScenarioContext _scenarioContext;
    private readonly FeatureContext _featureContext;

    public SpecFlowHooks(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        Console.WriteLine("SpecFlow BeforeTestRun");
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        Console.WriteLine($"Feature started: {featureContext.FeatureInfo.Title}");
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        Console.WriteLine($"Scenario started: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterStep]
    public void AfterStep()
    {
        if (_scenarioContext.TestError != null)
        {
            Console.WriteLine($"Step failed: {_scenarioContext.TestError.Message}");
        }
    }

    [AfterScenario]
    public void AfterScenario()
    {
        Console.WriteLine($"Scenario finished: {_scenarioContext.ScenarioInfo.Title}");
    }

    [AfterFeature]
    public static void AfterFeature(FeatureContext featureContext)
    {
        Console.WriteLine($"Feature finished: {featureContext.FeatureInfo.Title}");
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        Console.WriteLine("SpecFlow AfterTestRun");
    }
}
