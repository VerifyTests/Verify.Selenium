﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using VerifyTests;
using VerifyNUnit;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

[TestFixture]
public class TheTests : IDisposable
{
    IWebHost server;
    RemoteWebDriver driver;

    public TheTests()
    {
        var webBuilder = new WebHostBuilder();

        webBuilder.UseStartup<Startup>();
        webBuilder.UseKestrel();
        server = webBuilder.Build();
        server.Start();

        #region BuildDriver

        var options = new ChromeOptions();
        options.AddArgument("--no-sandbox");
        options.AddArgument("--headless");
        driver = new ChromeDriver(options);
        driver.Manage().Window.Size = new Size(1024, 768);
        driver.Navigate().GoToUrl("http://localhost:5000");

        #endregion
    }

    [Test]
    public async Task PageUsage()
    {
        #region PageUsage

        await Verifier.Verify(driver);

        #endregion
    }

    [Test]
    public async Task ElementUsage()
    {
        #region ElementUsage

        var element = driver.FindElement(By.Id("someId"));
        await Verifier.Verify(element);

        #endregion
    }

    static TheTests()
    {
        #region Enable

        VerifySelenium.Enable();

        #endregion

        VerifyPhash.RegisterComparer("png", .99f);
    }

    public void Dispose()
    {
        server.Dispose();
        driver.Dispose();
    }
}