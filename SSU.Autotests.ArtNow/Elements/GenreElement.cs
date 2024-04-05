using System.ComponentModel;
using EnumsNET;
using OpenQA.Selenium;

namespace SSU.Autotests.ArtNow.Elements;

public class GenreElement
{
    private IWebDriver _webDriver;

    public GenreElement(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void Select(params Genre[] genres)
    {
        _webDriver.FindElement(By.XPath("//span[@data-show='genrebox']/span[text()='Показать все']")).Click();
        var genresList = _webDriver.FindElement(By.XPath("//div[@id='genrebox']/div"));
        foreach (var genre in genres)
        {
            var genreName = genre.AsString(EnumFormat.Description);
            genresList.FindElement(By.XPath($"//label[contains(text(), '{genreName}')]")).Click();
        }
        
        _webDriver.FindElement(By.XPath("//div[@id='applymsg']")).Click();
    }

    public enum Genre
    {
        [Description("Пейзаж")] Scenery,
        [Description("Городской пейзаж")] Cityscape,
    }
}