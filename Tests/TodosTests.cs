using Allure.Commons;
using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using PlaywrightTestFramework.Pages;
using PlaywrightTestFramework.Reports;
using System.IO;


namespace PlaywrightTestFramework.Tests;

[AllureNUnit]
public class TodosTests
{
    private IPlaywright? _playwright;
    private IBrowser? _browser;
    private IPage? _page;

    [SetUp]
    public async Task SetUp()
    {
        AllureReports.Configure();
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(
                        new BrowserTypeLaunchOptions { Headless = true });
        _page = await _browser.NewPageAsync();

    }
    [Test, Category("PortfolioDemo")]
    [AllureTag("smoke")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureFeature("Demo Test")]
    public async Task AddAndToggleTodo_ShouldMarkItemCompleted()
    {
        var todo = new TodosPage(_page!);
        await todo.NavigateAsync();

        const string todoText = "Write awesome Playwright tests";
        await todo.AddTodoAsync(todoText);

        Assert.That(await todo.GetFirstTodoTextAsync(), Is.EqualTo(todoText));

        await todo.ToggleFirstTodoAsync();
        var classAttr = await _page!.Locator("ul.todo-list li:first-child")
                                    .GetAttributeAsync("class");
        Assert.That(classAttr, Does.Contain("completed"));
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status ==
            NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            Directory.CreateDirectory("Screenshots");
            var file = Path.Combine("Screenshots",
                      $"{TestContext.CurrentContext.Test.Name + DateTime.Today.ToString("dd MM yyyy hh mm ss")}.png");
            await _page!.ScreenshotAsync(new PageScreenshotOptions { Path = file });
            Console.WriteLine($"Screenshot saved to: {Path.GetFullPath(file)}");
            AllureLifecycle.Instance.AddAttachment("Failure Screenshot", "image/png", file);

        }

        await _browser!.CloseAsync();
        _playwright!.Dispose();
    }
}