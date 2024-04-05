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
    
    public static HeaderElement Header(this IWebDriver webDriver)
    {
        return new HeaderElement(webDriver.FindElement(By.XPath("//div[@class='topheader']")));
    }
    
    public static CatalogPageObject CatalogPage(this IWebDriver webDriver)
    {
        return new CatalogPageObject(webDriver);
    }
    
    public static BasketPageObject BasketPage(this IWebDriver webDriver)
    {
        return new BasketPageObject(webDriver);
    }
    
    public static PicturePageObject PicturePage(this IWebDriver webDriver)
    {
        return new PicturePageObject(webDriver);
    }
}