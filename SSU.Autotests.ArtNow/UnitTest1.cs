using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SSU.Autotests.ArtNow.Elements;
using SSU.Autotests.ArtNow.Extensions;

namespace SSU.Autotests.ArtNow;

public class Tests
{
    IWebDriver _artNowDriver;

    [SetUp]
    public void Setup()
    {
        _artNowDriver = new ChromeDriver
        {
            Url = "https://artnow.ru/"
        };
        _artNowDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void OpenEmbroideredPaintings_SelectCityscapeGenre_ShouldContainExpectedPictureName()
    {
        // ARRANGE
        const string expectedPictureName = "Трамвайный путь";
        
        // Переход в вышитые картины
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.EmbroideredPaintings);
        
        // Применение фильтра «Городской пейзаж»
        _artNowDriver.ChapterPage().Genre().Select(GenreElement.Genre.Cityscape);
        
        // Получение всех картин на странице
        var actualPictureNames = _artNowDriver.ChapterPage().Posts();

        // ASSERT
        actualPictureNames.Should().Contain(x => x.Header().Contains(expectedPictureName));
    }
    
    [Test]
    public void OpenEmbroideredPaintings_SelectCityscapeGenre_OpenPicturePage_StyleShouldBeExpected()
    {
        // ARRANGE
        const string expectedStyleName = "Реализм";
        const string pictureName = "Трамвайный путь";
        
        // Переход в вышитые картины
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.EmbroideredPaintings);
        
        // Применение фильтра «Городской пейзаж»
        _artNowDriver.ChapterPage().Genre().Select(GenreElement.Genre.Cityscape);
        
        // Клик на товар
        var posts = _artNowDriver.ChapterPage().Posts();
        posts.First(x => x.Header().Contains(pictureName)).Click();

        // Получение названия стиля
        var actualStyleName = _artNowDriver.PicturePage().Style();
        
        // ASSERT
        actualStyleName.Should().Be(expectedStyleName);
    }
    
    [Test]
    public void OpenBatik()
    {
        // ARRANGE
        const string expectedStyleName = "Реализм";
        const string pictureName = "Трамвайный путь";
        
        // Переход в батик
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.Batik);
        Console.WriteLine();
        // ASSERT
        // actualStyleName.Should().Be(expectedStyleName);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        _artNowDriver.Dispose();
    }
}