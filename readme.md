# <img src="/src/icon.png" height="30px"> Verify.Selenium

[![Build status](https://ci.appveyor.com/api/projects/status/xbfm80k15vfqosnd?svg=true)](https://ci.appveyor.com/project/SimonCropp/verify-selenium)
[![NuGet Status](https://img.shields.io/nuget/v/Verify.Selenium.svg)](https://www.nuget.org/packages/Verify.Selenium/)

Extends [Verify](https://github.com/VerifyTests/Verify) to allow verification of Web UIs using [Selenium](https://www.selenium.dev/).

Support is available via a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-verify?utm_source=nuget-verify&utm_medium=referral&utm_campaign=enterprise).

<a href='https://dotnetfoundation.org' alt='Part of the .NET Foundation'><img src='https://raw.githubusercontent.com/VerifyTests/Verify/master/docs/dotNetFoundation.svg' height='30px'></a><br>
Part of the <a href='https://dotnetfoundation.org' alt=''>.NET Foundation</a>

<!-- toc -->
## Contents

  * [Selenium Usage](#selenium-usage)
    * [Enable](#enable)
    * [Build WebDriver](#build-webdriver)
    * [Page test](#page-test)
    * [Element test](#element-test)
  * [OS specific rendering](#os-specific-rendering)
  * [Security contact information](#security-contact-information)<!-- endToc -->


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
        One hears it stated that a factor within the logical radical priority embodies the key principles behind the best practice marginalised certification project. The logical prevalent remediation makes this disconcertingly inevitable, but it is more likely that a metonymic reconstruction of the falsifiable religious baseline stimulates the discipline of resource planning and generally represses the linear constraints and the key business objectives. The item is of a monitored nature.
      </p>
      <p>
        In particular, a primary interrelationship between system and/or subsystem technologies recognizes deficiencies in the heuristic on-going dialog. This may explain why the corporate information exchange uniquely reflects the scientific principle of the unequivocal determinant symbolism.
      </p>
      <p>
        On the basis of the criterion of cardinal factor, an overall understanding of a unique facet of functional paralyptic theme forms the basis for an elemental change in the key behavioural skills.
      </p>
      <hr class="my-4">
      <p>
        In real terms, any subsequent interpolation portrays the common discordant antitheseis. This may be due to a lack of a empirical correspondence.
      </p>
      <a id="someId" class="btn btn-primary btn-lg" href="#" role="button">
        Learn more
      </a>
    </div>
  </body>
</html>
```
<sup><a href='/src/Tests/SeleniumTests.PageUsage.00.verified.html#L1-L28' title='Snippet source file'>snippet source</a> | <a href='#snippet-SeleniumTests.PageUsage.00.verified.html' title='Start of snippet'>anchor</a></sup>
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
    <a id="someId" class="btn btn-primary btn-lg" href="#" role="button">
      Learn more
    </a>
  </body>
</html>
```
<sup><a href='/src/Tests/SeleniumTests.ElementUsage.00.verified.html#L1-L8' title='Snippet source file'>snippet source</a> | <a href='#snippet-SeleniumTests.ElementUsage.00.verified.html' title='Start of snippet'>anchor</a></sup>
<!-- endSnippet -->

[SeleniumTests.ElementUsage.01.verified.png](/src/Tests/SeleniumTests.ElementUsage.01.verified.png):

<img src="/src/Tests/SeleniumTests.ElementUsage.01.verified.png">


## OS specific rendering

The rendering can very slightly between different OS versions. This can make verification on different machines (eg CI) problematic. A [custom comparer](https://github.com/VerifyTests/Verify/blob/master/docs/comparer.md) can to mitigate this.


## Security contact information

To report a security vulnerability, use the [Tidelift security contact](https://tidelift.com/security). Tidelift will coordinate the fix and disclosure.


## Icon

[Crystal](https://thenounproject.com/term/crystal/1440050/) designed by [Monjin Friends](https://thenounproject.com/monjin.friends) from [The Noun Project](https://thenounproject.com/creativepriyanka).
