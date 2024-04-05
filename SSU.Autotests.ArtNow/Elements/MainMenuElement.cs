using System.ComponentModel;
using EnumsNET;
using OpenQA.Selenium;

namespace SSU.Autotests.ArtNow.Elements;

public class MainMenuElement
{
    private IWebElement _webElement;

    public MainMenuElement(IWebElement webElement)
    {
        _webElement = webElement;
    }

    public void ClickOnCategory(Category category)
    {
        var categoryName = category.AsString(EnumFormat.Description);
        //_webElement.FindElement(By.XPath($"//ul[2]/li[contains(text(), '{categoryName}')]")).Click();
        _webElement.FindElement(By.XPath("//ul[2]/li[@class='menu-group gids']/div")).Click();
        _webElement.FindElement(By.XPath($"//ul[2]/li/a[contains(text(), '{categoryName}')]")).Click();
        Console.WriteLine();
    }
    
    public enum Category
    {
        [Description("Живопись")] Painting,
        [Description("Вышитые картины")] EmbroideredPaintings,
        [Description("Батик")] Batik,
    }
}