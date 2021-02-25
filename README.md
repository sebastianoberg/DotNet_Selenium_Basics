# DotNet_Selenium_Basics

## For testers and QA's Selenium is an important tool when looking for new assignments/jobs, I hope this repo can inspire testers & QA's to learn how to use Selenium.

**There are two tests, and they both do the same. First test is:**
1. Basic flow implemented not using any particular pattern. The test steps are just run through, up and down. 

**Second one is more intuitive:**
2. Same basic flow as the first test BUT implemented using Page Object Model (POM). As you will see this test is way easier to follow.

#Other advantages of "POM" is: 
* It way more clean and understandable - Less code, dedicated and shared code.
* Easy to maintain - you always know where to change your code. For example locators and elements.
* Easy to find and follow in the UI. Page Object are essentially the different parts of your website.

**These two tests are executed using .NET CORE, and I run them on my MacBook Pro. What you will need:**
1. Chrome web browser
2. Visual Studio for Mac (https://visualstudio.microsoft.com/vs/mac/)
3. Chrome WebDriver (Download from :https://chromedriver.chromium.org/downloads, build the solution using Visual Studio and copy the chromedriver executable to "Selenium_DotNet\Demo.SeleniumTests\bin\Debug\netcoreapp2.2​")
4. .NET Core SDK (https://dotnet.microsoft.com/download)
