using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;    

public class Reports
{
    public static ExtentReports extentReports;
    public static ExtentHtmlReporter extentHtmlReporter;
    public static ExtentTest extentTest;

    public static void InitializeExtentReports(string path, string docTitle, string reportName)
    {
        extentHtmlReporter = new ExtentHtmlReporter(path);
        extentHtmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
        extentHtmlReporter.Config.DocumentTitle = docTitle;
        extentHtmlReporter.Config.ReportName = reportName;
        extentReports = new ExtentReports();
        extentReports.AttachReporter(extentHtmlReporter);
    }

    public static void CreateTest(string testName)
    {
        extentTest = extentReports.CreateTest(testName);
    }

    public static void Log(Status status, string message)
    {
        extentTest.Log(status, message);
    }

    public static void FlushExtentReports()
    {
        extentReports.Flush();
    }

    public static void TestStatus(Status status, string message)
    {
        extentTest.Log(status, message);
    }
}