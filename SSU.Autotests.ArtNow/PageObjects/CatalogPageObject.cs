using OpenQA.Selenium;
using SSU.Autotests.ArtNow.Elements;

namespace SSU.Autotests.ArtNow.PageObjects;

public class CatalogPageObject
{
    const string _postXPath = "//div[@class='post']";
    
    private readonly IWebDriver _webDriver;

    public CatalogPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public GenreElement Genre()
    {
        return new GenreElement(_webDriver);
    }
    
    public IReadOnlyList<string> ProductNames()
    {
        WaitLoad();

        return _webDriver.FindElements(By.XPath($"{_postXPath}/a/div[@class='ssize']"))
            .Select(x => x.Text)
            .ToList();
    }
    
    public IReadOnlyList<string> ProductPrices()
    {
        WaitLoad();

        return _webDriver.FindElements(By.XPath($"//div[@class='price']"))
            .Select(x => x.Text.Split("\r\n")[0])
            .ToList();
    }

    public void AddToBasket(int index)
    {
        _webDriver.FindElement(By.XPath($"//div[contains(text(), 'Купить')][{index}]")).Click();
        _webDriver.FindElement(By.XPath($"//button[@class='continue']")).Click();
    }
    
    public void AddToFavorite(int index)
    {
        _webDriver.FindElement(By.XPath($"//div[@class='heart'][{index}]")).Click();
    }
    
    public void ClickToProduct(string name)
    {
        WaitLoad();
        
        //_webDriver.FindElement(By.XPath($"{_postXPath}/a/div[contains(text(), '{name}')]")).Click();
        foreach (var header in _webDriver.FindElements(By.XPath($"{_postXPath}/a/div[@class='ssize']")))
        {
            if (header.Text.Contains(name))
            {
                header.Click();
                return;
            }
        }
    }
    
    private void WaitLoad()
    {
        // Нужно для неявного ожидания загрузки товаров
        _webDriver.FindElement(By.XPath($"{_postXPath}/a/div[@class='ssize']"));
    }


}