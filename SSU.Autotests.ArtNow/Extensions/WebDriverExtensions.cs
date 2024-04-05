using OpenQA.Selenium;
using SSU.Autotests.ArtNow.Elements;
using SSU.Autotests.ArtNow.PageObjects;

namespace SSU.Autotests.ArtNow.Extensions;

public static class WebDriverExtensions
{
    public static MainMenuElement MainMenu(this IWebDriver webDriver)
    {
        return new MainMenuElement(webDriver.FindElement(By.XPath("//div[@class='main_menu']")));
    }
    
    public static ChapterPageObject ChapterPage(this IWebDriver webDriver)
    {
        return new ChapterPageObject(webDriver);
    }
    
    public static PicturePageObject PicturePage(this IWebDriver webDriver)
    {
        return new PicturePageObject(webDriver);
    }
}