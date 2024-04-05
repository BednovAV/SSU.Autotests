using OpenQA.Selenium;

namespace SSU.Autotests.ArtNow.Elements;

public class HeaderElement
{
    private IWebElement _webElement;

    public HeaderElement(IWebElement webElement)
    {
        _webElement = webElement;
    }
    
    public void ClickOnFavorite()
    {
        _webElement.FindElement(By.XPath("//span[@class='fvtico']")).Click();
    }
    
    public void ClickOnBasket()
    {
        _webElement.FindElement(By.XPath("//span[@class='basketico']")).Click();
    }

    public void Search(string text)
    {
        _webElement.FindElement(By.XPath("//input[@name='qs']")).SendKeys(text);
        _webElement.FindElement(By.XPath("//button[contains(text(), 'Искать')]")).Click();
    }
}