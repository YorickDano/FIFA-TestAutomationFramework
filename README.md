# FIFA Test Automation Framework

A robust C#-based Test Automation Framework designed for testing FIFA-related applications and web services. This framework implements modern testing practices including Behavior-Driven Development (BDD), API testing, and UI automation.

![Test Automation](https://img.shields.io/badge/Test-Automation-blue)
![C#](https://img.shields.io/badge/Language-C%23-green)
![Selenium](https://img.shields.io/badge/WebDriver-Selenium-orange)

## 🚀 Features

- **Behavior-Driven Development (BDD)**: Write tests in natural language using SpecFlow
- **Multi-Layer Testing**: Support for API testing, UI testing, and integration testing
- **API Testing**: Comprehensive REST API testing using RestSharp/HttpClient
- **Web UI Automation**: Selenium WebDriver for browser-based testing
- **CI/CD Integration**: Jenkins pipeline for continuous testing
- **Page Object Model**: Maintainable and scalable test architecture
- **Extensive Reporting**: Detailed test execution reports
- **Data-Driven Testing**: Support for multiple test data sources

## 🛠️ Technology Stack

### Core Framework
- **Programming Language**: C# (.NET 6/7)
- **Testing Framework**: NUnit / xUnit
- **BDD Framework**: SpecFlow
- **Web Automation**: Selenium WebDriver
- **API Testing**: RestSharp / HttpClient
- **Build Tool**: MSBuild

### CI/CD & Tools
- **CI/CD Server**: Jenkins
- **Version Control**: Git
- **Test Reporting**: Extent Reports / Allure
- **Package Management**: NuGet

## 📁 Project Structure
FIFA-TestAutomationFramework/
├── src/
│ ├── Framework/ # Core framework components
│ ├── Pages/ # Page Object Models
│ ├── StepDefinitions/ # SpecFlow step definitions
│ ├── Features/ # Gherkin feature files
│ ├── Models/ # Data models and DTOs
│ └── Utilities/ # Helper classes and utilities
├── tests/
│ ├── APITests/ # API test suites
│ ├── UITests/ # Web UI test suites
│ └── IntegrationTests/ # End-to-end test suites
├── config/
│ ├── appsettings.json # Configuration files
│ └── jenkinsfile # CI/CD pipeline
└── reports/ # Test execution reports

⚙️ Installation & Setup
Prerequisites
.NET 6.0 SDK or later
Visual Studio 2022 or VS Code
Chrome/Firefox browsers

Quick Start
Clone the repository

git clone https://github.com/YorickDano/FIFA-TestAutomationFramework.git
cd FIFA-TestAutomationFramework
Restore NuGet packages

dotnet restore
Run tests

# Run all tests
dotnet test

# Run specific test category
dotnet test --filter "Category=API"
dotnet test --filter "Category=UI"
📝 Writing Tests
Feature File (BDD)

Feature: FIFA Player Search
    As a FIFA user
    I want to search for players
    So that I can find specific player information

Scenario: Search for existing player
    Given I am on the FIFA players page
    When I search for "Lionel Messi"
    Then I should see player details for "Lionel Messi"
    And the player nationality should be "Argentina"
Step Definition

[Binding]
public class PlayerSearchSteps
{
    private readonly PlayersPage _playersPage;
    
    [When(@"I search for ""(.*)""")]
    public void WhenISearchFor(string playerName)
    {
        _playersPage.SearchPlayer(playerName);
    }
    
    [Then(@"I should see player details for ""(.*)""")]
    public void ThenIShouldSeePlayerDetailsFor(string expectedPlayer)
    {
        var actualPlayer = _playersPage.GetPlayerName();
        actualPlayer.Should().Be(expectedPlayer);
    }
}
Page Object Model

public class PlayersPage
{
    private readonly IWebDriver _driver;
    
    private IWebElement SearchInput => _driver.FindElement(By.Id("player-search"));
    private IWebElement SearchButton => _driver.FindElement(By.Id("search-btn"));
    
    public PlayersPage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    public void SearchPlayer(string playerName)
    {
        SearchInput.Clear();
        SearchInput.SendKeys(playerName);
        SearchButton.Click();
    }
}
🔧 Configuration
appsettings.json
json
{
  "BaseUrl": "https://fifa-web-app.com",
  "ApiBaseUrl": "https://api.fifa.com/v1",
  "Browser": "Chrome",
  "Timeout": 30,
  "Headless": false,
  "TestData": {
    "AdminUser": "test_admin",
    "DefaultPassword": "Test123!"
  }
}
🚦 Running Tests
Local Execution

# Run all tests
dotnet test

# Run with specific categories
dotnet test --filter "TestCategory=Smoke"
dotnet test --filter "TestCategory=Regression"

# Run with specific browser
set Browser=Firefox
dotnet test
Jenkins Pipeline
groovy
pipeline {
    agent any
    stages {
        stage('Build') {
            steps {
                bat 'dotnet restore'
                bat 'dotnet build'
            }
        }
        stage('Test') {
            steps {
                bat 'dotnet test --logger:trx --results-directory:TestResults'
            }
        }
        stage('Report') {
            steps {
                publishHTML([
                    allowMissing: false,
                    alwaysLinkToLastBuild: true,
                    keepAll: true,
                    reportDir: 'TestResults',
                    reportFiles: '*.html',
                    reportName: 'HTML Report'
                ])
            }
        }
    }
}
📊 Test Reports
The framework generates comprehensive reports including:
HTML Reports: Detailed test execution results
Allure Reports: Interactive test reporting
TRX Reports: Visual Studio compatible results
Console Output: Real-time test progress

🤝 Contributing
We welcome contributions! Please feel free to submit pull requests or open issues for bugs and feature requests.

Development Guidelines
Follow Page Object Model pattern
Write BDD scenarios before implementation
Use meaningful step definition names
Add appropriate test categories
Ensure all tests are independent

📄 License
This project is licensed under the MIT License - see the LICENSE file for details.

👨‍💻 Author
Nikita Levdanskii
Email: nikitalevdanskii@gmail.com
GitHub: YorickDano
Telegram: @lev_skii

🙏 Acknowledgments
SpecFlow team for excellent BDD support
Selenium WebDriver community
EPAM Systems for training and guidance
FIFA development team for test applications
