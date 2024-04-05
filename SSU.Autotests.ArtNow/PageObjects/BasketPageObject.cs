using OpenQA.Selenium;

namespace SSU.Autotests.ArtNow.PageObjects;

public class BasketPageObject
{
    private readonly IWebDriver _webDriver;

    public BasketPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public IReadOnlyList<string> ProductNames()
    {
        return _webDriver.FindElements(By.XPath($"//div[@class='c_name']/a"))
            .Select(x => x.Text)
            .ToList();
    }
    
    public IReadOnlyList<string> ProductPrices()
    {
        return _webDriver.FindElements(By.XPath($"//div[@class='price']"))
            .Select(x => x.Text.Split("\r\n")[0])
            .ToList();
    }
}