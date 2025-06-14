using Allure.Commons;

namespace PlaywrightTestFramework.Reports;

public class AllureReports
{
    public static string ResultDirectory => "Reports/Allure/results";

    public static void Configure()
    {
        Environment.SetEnvironmentVariable("ALLURE_RESULTS_DIRECTORY", ResultDirectory);
        AllureLifecycle.Instance.CleanupResultDirectory();
    }
}
