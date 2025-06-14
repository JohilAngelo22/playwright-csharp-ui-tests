using Microsoft.Playwright;

namespace PlaywrightTestFramework.Pages;

public class TodosPage(IPage page)
{
    private readonly IPage _page = page;

    private ILocator NewTodoInput => _page.Locator(".new-todo");
    private ILocator FirstTodoLabel => _page.Locator("ul.todo-list li:first-child label");
    private ILocator FirstTodoToggle => _page.Locator("ul.todo-list li:first-child .toggle");

    public async Task NavigateAsync()
        => await _page.GotoAsync("https://demo.playwright.dev/todomvc");

    public async Task AddTodoAsync(string text)
    {
        await NewTodoInput.FillAsync(text);
        await NewTodoInput.PressAsync("Enter");
    }

    public async Task<string> GetFirstTodoTextAsync()
        => await FirstTodoLabel.InnerTextAsync();

    public async Task ToggleFirstTodoAsync()
        => await FirstTodoToggle.ClickAsync();
}
