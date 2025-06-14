## 🔪 Playwright C# UI Test Automation Framework

Welcome to the **PlaywrightTestFramework** — a scalable, modern UI automation solution built with:

* 💻 **.NET 8**
* 🔪 **Playwright for .NET**
* 🐳 **Docker**
* 🚀 **CI via GitHub Actions**
* 📦 **NuGet Tooling**

This framework demonstrates best practices in UI automation using Playwright with C#, designed for clean test architecture, easy CI/CD integration, and Docker-based test execution.

---

### 📁 Project Structure

```
PlaywrightTestFramework/
├── Tests/                          # Test classes using NUnit
├── Pages/                          # Page Object Models
├── Drivers/                        # Browser initialization and test lifecycle
├── Utilities/                      # Helpers, constants, config readers
├── Dockerfile                      # Docker support to run tests in container
├── playwright.docker.yml          # GitHub Action to run tests via Docker
├── playwright-ci.yml              # GitHub Action for native CI testing
├── PlaywrightTestFramework.csproj # Project file
```

---

### ⚙️ Technologies Used

| Tool           | Purpose                                  |
| -------------- | ---------------------------------------- |
| .NET 8         | Test project runtime                     |
| Playwright     | UI automation engine                     |
| NUnit          | Test framework                           |
| Docker         | Containerized test execution             |
| GitHub Actions | Continuous Integration & Test Automation |

---

### 🚀 How to Run Tests Locally

#### 🖥 Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
* [Node.js](https://nodejs.org/) (Playwright dependency)
* [PowerShell Core](https://learn.microsoft.com/en-us/powershell/)
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) (for container support)

#### 🔪 Run via CLI

```bash
# Restore tools and dependencies
dotnet restore
dotnet tool restore

# Build project
dotnet build

# Install browsers
dotnet playwright install

# Run tests
dotnet test --configuration Release
```

---

### 🐳 Run Tests in Docker

```bash
docker build -t playwright-csharp-ui-tests .
docker run --rm playwright-csharp-ui-tests
```

> ✔ Dockerfile is configured to install necessary dependencies, build the app, and execute tests inside a container.

---

### 🧪 GitHub CI Workflows

#### ✅ `playwright-ci.yml`

Runs tests automatically on push or PR to `master`:

```yaml
on:
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]
```

#### 🔁 `playwright-docker.yml`

Manually trigger Docker-based test run:

```yaml
on:
  workflow_dispatch:
```

Run from GitHub UI ➔ Actions ➔ Select Workflow ➔ Run workflow.

---

### 🧬 Features

* 🧱 **Page Object Model**: Test logic separated from UI selectors.
* 🔄 **Reusable Hooks**: NUnit SetUp/TearDown support for test lifecycle.
* ⚙️ **Cross-browser ready**: Can run on Chromium, Firefox, WebKit.
* 📦 **Docker-ready**: Simplifies CI and remote test execution.
* 📊 **Scalable for CI/CD**: Plug into pipelines seamlessly.

---

### 📸 Sample Test

```csharp
[Test]
public async Task AddAndToggleTodo_ShouldMarkItemCompleted()
{
    await Page.GotoAsync("https://example-todo-app.com");
    await Page.FillAsync("#new-todo", "Learn Playwright");
    await Page.ClickAsync("#add-todo");
    await Page.ClickAsync(".todo-item >> text=Learn Playwright");
    Assert.True(await Page.IsCheckedAsync(".todo-item.completed"));
}
```

---

### 🧠 Dockerfile Explained

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Install dependencies required by Playwright browsers
RUN apt-get update && apt-get install -y <browser-deps>

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet build

# Add Playwright tool and install browsers
RUN dotnet tool install --global Microsoft.Playwright.CLI
ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet playwright install

CMD ["dotnet", "test", "--configuration", "Release"]
```

---

### 🤝 Contributing

PRs, feature requests, and ideas are welcome! Feel free to fork and suggest enhancements to improve the test architecture or CI pipeline.

---

### 📜 License

This project is licensed under the [MIT License](LICENSE)

---

### 👤 Author

**Johil Angelo**
🔗 [GitHub Profile](https://github.com/JohilAngelo22)
🔗 [LinkedIn](https://www.linkedin.com/in/johil-angelo-aa66b91b5/)
