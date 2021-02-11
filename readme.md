# <img src="/src/icon.png" height="30px"> Verify.Selenium

[![Build status](https://ci.appveyor.com/api/projects/status/xbfm80k15vfqosnd?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-selenium)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Selenium.svg)](https://www.nuget.org/packages/Verify.Selenium/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of Web UIs using [Selenium](https://www.selenium.dev/).

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-verify?utm_source=nuget-verify&utm_medium=referral&utm_campaign=enterprise).

<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>

<!-- toc -->
## Contents

  * [Playwright Usage](#playwright-usage)
    * [Enable](#enable)
    * [Build](#build)
    * [Page test](#page-test)
    * [Element test](#element-test)
  * [Selenium Usage](#selenium-usage)
    * [Enable](#enable-1)
    * [Build WebDriver](#build-webdriver)
    * [Page test](#page-test-1)
    * [Element test](#element-test-1)
  * [OS specific rendering](#os-specific-rendering)
  * [Security contact information](#security-contact-information)<!-- endToc -->


## Playwright Usage


### NuGet package

https://nuget.org/packages/Verify.Playwright/


### Enable

Enable VerifyPlaywright once at assembly load time:

<!-- snippet: PlaywrightEnable -->
<a id='snippet-playwrightenable'></a>
```cs
VerifyPlaywright.Enable();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L15-L19' title='Snippet source file'>snippet source</a> | <a href='#snippet-playwrightenable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Build

<!-- snippet: PlaywrightBuild -->
<a id='snippet-playwrightbuild'></a>
```cs
playwright = await Playwright.CreateAsync();
browser = await playwright.Chromium.LaunchAsync();
```
<sup><a href='/src/Tests/PlaywrightFixture.cs#L16-L21' title='Snippet source file'>snippet source</a> | <a href='#snippet-playwrightbuild' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Page test

The current page state can be verified as follows:

<!-- snippet: PlaywrightPageUsage -->
<a id='snippet-playwrightpageusage'></a>
```cs
var page = await browser.NewPageAsync();
await page.GoToAsync("http://localhost:5000");
await Verifier.Verify(page);
```
<sup><a href='/src/Tests/PlaywrightTests.cs#L21-L27' title='Snippet source file'>snippet source</a> | <a href='#snippet-playwrightpageusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the element being rendered as a verified files:

<!-- snippet: PlaywrightTests.PageUsage.00.verified.html -->
<a id='snippet-PlaywrightTests.PageUsage.00.verified.html'></a>
```html
<!DOCTYPE html><html lang="en"><head>
  <meta charset="utf-8">
  <title>The Title</title>
  <link href="https://getbootstrap.com/docs/4.0/dist/css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
  <div class="jumbotron">
    <h1 class="display-4">The Awareness Of Relative Idealism</h1>
    <p class="lead">
      One hears it stated that a factor within the logical radical priority embodies the
      key principles behind the best practice marginalised certification project. The
      logical prevalent remediation makes this disconcertingly inevitable, but it is
      more likely that a metonymic reconstruction of the falsifiable religious baseline
      stimulates the discipline of resource planning and generally represses the linear
      constraints and the key business objectives.
    </p>
    <a id="someId" class="btn btn-primary btn-lg" href="#" role="button">Learn more</a>
  </div>

</body></html>
```
<sup><a href='/src/Tests/PlaywrightTests.PageUsage.00.verified.html#L1-L20' title='Snippet source file'>snippet source</a> | <a href='#snippet-PlaywrightTests.PageUsage.00.verified.html' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

[PlaywrightTests.PageUsage.01.verified.png](/src/Tests/PlaywrightTests.PageUsage.01.verified.png):

<img src="/src/Tests/PlaywrightTests.PageUsage.01.verified.png" width="400px">


### Element test

An element can be verified as follows:

<!-- snippet: PlaywrightElementUsage -->
<a id='snippet-playwrightelementusage'></a>
```cs
var page = await browser.NewPageAsync();
await page.GoToAsync("http://localhost:5000");
await page.WaitForLoadStateAsync(LifecycleEvent.Networkidle);
var element = await page.QuerySelectorAsync("#someId");
await Verifier.Verify(element);
```
<sup><a href='/src/Tests/PlaywrightTests.cs#L33-L41' title='Snippet source file'>snippet source</a> | <a href='#snippet-playwrightelementusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the element being rendered as a verified files:

<!-- snippet: PlaywrightTests.ElementUsage.00.verified.html -->
<a id='snippet-PlaywrightTests.ElementUsage.00.verified.html'></a>
```html
Learn more
```
<sup><a href='/src/Tests/PlaywrightTests.ElementUsage.00.verified.html#L1-L1' title='Snippet source file'>snippet source</a> | <a href='#snippet-PlaywrightTests.ElementUsage.00.verified.html' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

[PlaywrightTests.ElementUsage.01.verified.png](/src/Tests/PlaywrightTests.ElementUsage.01.verified.png):

<img src="/src/Tests/PlaywrightTests.ElementUsage.01.verified.png">


## Selenium Usage


### NuGet package

https://nuget.org/packages/Verify.Selenium/


### Enable

Enable VerifySelenium once at assembly load time:

<!-- snippet: SeleniumEnable -->
<a id='snippet-seleniumenable'></a>
```cs
VerifySelenium.Enable();
```
<sup><a href='/src/Tests/ModuleInitializer.cs#L9-L13' title='Snippet source file'>snippet source</a> | <a href='#snippet-seleniumenable' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Build WebDriver

<!-- snippet: SeleniumBuildDriver -->
<a id='snippet-seleniumbuilddriver'></a>
```cs
ChromeOptions options = new();
options.AddArgument("--no-sandbox");
options.AddArgument("--headless");
Driver = new(options);
Driver.Manage().Window.Size = new(1024, 768);
Driver.Navigate().GoToUrl("http://localhost:5000");
```
<sup><a href='/src/Tests/SeleniumFixture.cs#L12-L21' title='Snippet source file'>snippet source</a> | <a href='#snippet-seleniumbuilddriver' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->


### Page test

The current page state can be verified as follows:

<!-- snippet: SeleniumPageUsage -->
<a id='snippet-seleniumpageusage'></a>
```cs
await Verifier.Verify(driver);
```
<sup><a href='/src/Tests/SeleniumTests.cs#L21-L25' title='Snippet source file'>snippet source</a> | <a href='#snippet-seleniumpageusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the element being rendered as a verified files:

<!-- snippet: SeleniumTests.PageUsage.00.verified.html -->
<a id='snippet-SeleniumTests.PageUsage.00.verified.html'></a>
```html
<html lang="en">
  <head>
    <meta charset="utf-8">
    <title>The Title</title>
    <link href="https://getbootstrap.com/docs/4.0/dist/css/bootstrap.min.css" rel="stylesheet">
  </head>
  <body>
    <div class="jumbotron">
      <h1 class="display-4">The Awareness Of Relative Idealism</h1>
      <p class="lead">
        One hears it stated that a factor within the logical radical priority embodies the       key principles behind the best practice marginalised certification project. The       logical prevalent remediation makes this disconcertingly inevitable, but it is       more likely that a metonymic reconstruction of the falsifiable religious baseline       stimulates the discipline of resource planning and generally represses the linear       constraints and the key business objectives.
      </p>
      <a id="someId" class="btn btn-primary btn-lg" href="#" role="button">Learn more</a>
    </div>
  </body>
</html>
```
<sup><a href='/src/Tests/SeleniumTests.PageUsage.00.verified.html#L1-L16' title='Snippet source file'>snippet source</a> | <a href='#snippet-SeleniumTests.PageUsage.00.verified.html' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

[SeleniumTests.PageUsage.01.verified.png](/src/Tests/SeleniumTests.PageUsage.01.verified.png):

<img src="/src/Tests/SeleniumTests.PageUsage.01.verified.png" width="400px">


### Element test

An element can be verified as follows:

<!-- snippet: SeleniumElementUsage -->
<a id='snippet-seleniumelementusage'></a>
```cs
var element = driver.FindElement(By.Id("someId"));
await Verifier.Verify(element);
```
<sup><a href='/src/Tests/SeleniumTests.cs#L31-L36' title='Snippet source file'>snippet source</a> | <a href='#snippet-seleniumelementusage' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

With the state of the element being rendered as a verified files:

<!-- snippet: SeleniumTests.ElementUsage.00.verified.html -->
<a id='snippet-SeleniumTests.ElementUsage.00.verified.html'></a>
```html
<html>
  <head></head>
  <body>
    <a id="someId" class="btn btn-primary btn-lg" href="#" role="button">Learn more</a>
  </body>
</html>
```
<sup><a href='/src/Tests/SeleniumTests.ElementUsage.00.verified.html#L1-L6' title='Snippet source file'>snippet source</a> | <a href='#snippet-SeleniumTests.ElementUsage.00.verified.html' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

[SeleniumTests.ElementUsage.01.verified.png](/src/Tests/SeleniumTests.ElementUsage.01.verified.png):

<img src="/src/Tests/SeleniumTests.ElementUsage.01.verified.png">


## OS specific rendering

The rendering can very slightly between different OS versions. This can make verification on different machines (eg CI) problematic. A [custom comparer](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md) can to mitigate this.


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Crystal](https://thenounproject.com/term/crystal/1440050/) designed by [Monjin Friends](https://thenounproject.com/monjin.friends) from [The Noun Project](https://thenounproject.com/creativepriyanka).
