using OpenQA.Selenium;

namespace SSU.Autotests.ArtNow.Elements;

public class PostElement
{
    private readonly IWebElement _webElement;

    public PostElement(IWebElement webElement)
    {
        _webElement = webElement;
    }

    public string Header()
    {
        var header = _webElement.FindElement(By.XPath("//a/div[@class='ssize']")).Text;
        return header;
    }

    public void Click()
    {
        _webElement.Click();
    }
}