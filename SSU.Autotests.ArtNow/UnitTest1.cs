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
        _artNowDriver.Manage().Window.Maximize();
    }

    [Test]
    public void CatalogContainExpectedPictureNameTest()
    {
        // ARRANGE
        const string expectedPictureName = "Трамвайный путь";
        
        // Переход в вышитые картины
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.EmbroideredPaintings);
        
        // Применение фильтра «Городской пейзаж»
        _artNowDriver.CatalogPage().Genre().Select(GenreElement.Genre.Cityscape);
        
        // Получение всех картин на странице
        var actualPictureNames = _artNowDriver.CatalogPage().ProductNames();

        // ASSERT
        actualPictureNames.Should().Contain(x => x.Contains(expectedPictureName));
    }
    
    [Test]
    public void PictureShouldContainExpectedStyleTest()
    {
        // ARRANGE
        const string expectedStyleName = "Реализм";
        const string pictureName = "Трамвайный путь";
        
        // Переход в вышитые картины
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.EmbroideredPaintings);
        
        // Применение фильтра «Городской пейзаж»
        _artNowDriver.CatalogPage().Genre().Select(GenreElement.Genre.Cityscape);
        
        // Клик на товар
        _artNowDriver.CatalogPage().ClickToProduct(pictureName);

        // Получение названия стиля
        var actualStyleName = _artNowDriver.PicturePage().Style();
        
        // ASSERT
        actualStyleName.Should().Be(expectedStyleName);
    }
    
    [Test]
    public void AddPictureToFacotiteTest()
    {
        // Переход в батик
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.Batik);
        
        // Сохранение название первого товара в каталоге
        var expectedProductName = _artNowDriver.CatalogPage().ProductNames().First().RemoveNewLine();
        
        // Добавление первого товара в избранное
        _artNowDriver.CatalogPage().AddToFavorite(1);
        
        // Переход в избранное
        _artNowDriver.Header().ClickOnFavorite();
        
        // Сохранение название первого товара из каталога избранного
        var actualProductName = _artNowDriver.CatalogPage().ProductNames().First().RemoveNewLine();;

        // ASSERT
        actualProductName.Should().Be(expectedProductName);
    }
    
    [Test]
    public void SearchTest()
    {
        // ARRNGE
        const string searchTerm = "Жираф";
        
        // Поиск по слову
        _artNowDriver.Header().Search(searchTerm);
        
        // Сохранение название первого товара в каталоге
        var actualFirstProductName = _artNowDriver.CatalogPage().ProductNames().First();
        
        // ASSERT
        actualFirstProductName.Should().Contain(searchTerm);
    }
    
    [Test]
    public void AddToBasketTest()
    {
        // ACT
        
        // Переход в Ювелирное искусство
        _artNowDriver.MainMenu().ClickOnCategory(MainMenuElement.Category.JewelryArt);
        
        // Сохранение название первого товара в каталоге
        var expectedProductName = _artNowDriver.CatalogPage().ProductNames().First().RemoveNewLine();
        
        // Сохранение цены первого товара в каталоге
        var expectedProductPrice = _artNowDriver.CatalogPage().ProductPrices().First();
        
        // Добавление в корзину первого товара
        _artNowDriver.CatalogPage().AddToBasket(1); 
        
        // Переход в корзину
        _artNowDriver.Header().ClickOnBasket();

        // Сохранение названия товара из корзины
        var actualProductName = _artNowDriver.BasketPage().ProductNames().First();
        
        // Сохранение цены товара из корзины
        var actualProductPrice = _artNowDriver.BasketPage().ProductPrices().First();
        
        // ASSERT
        expectedProductName.Should().Contain(actualProductName);
        actualProductPrice.Should().Be(expectedProductPrice);
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        _artNowDriver.Dispose();
    }
}