using OpenQA.Selenium;

namespace SSU.Autotests.ArtNow.PageObjects;

public class PicturePageObject
{
    private readonly IWebDriver _webDriver;

    public PicturePageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public string Style()
    {
        return _webDriver.FindElement(By.XPath("//div[@class='infocontainer']/div[@class='txtline lft'][2]/a")).Text;
    }
}