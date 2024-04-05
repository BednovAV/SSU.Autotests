using OpenQA.Selenium;
using SSU.Autotests.ArtNow.Elements;

namespace SSU.Autotests.ArtNow.PageObjects;

public class ChapterPageObject
{
    private readonly IWebDriver _webDriver;

    public ChapterPageObject(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public GenreElement Genre()
    {
        return new GenreElement(_webDriver);
    }
    
    public IReadOnlyList<PostElement> Posts()
    {
        const string _postXPath = ".//div[@class='post']";
        
        // Нужно для неявного ожидания загрузки товаров
        _webDriver.FindElement(By.XPath($"{_postXPath}/a/div[@class='ssize']"));
        
        return _webDriver.FindElements(By.XPath(_postXPath))
            .Select(x => new PostElement(x))
            .ToList();
    }
}