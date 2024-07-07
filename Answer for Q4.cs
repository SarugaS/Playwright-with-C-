using System.Text.RegularExpressions;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightTests.Pages;

public class NUniPlayWright : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Page.GotoAsync("https://www.saucedemo.com/");
    }
    [Test]
    public async Task PageTest()
    {
        //Login Page #1
        LoginPage loginPage = new LoginPage(Page);
        await loginPage.Login("standard_user","secret_sauce");


        // Assertion: Expects page to have a heading with the name "Products".
        await loginPage.AssertLogin();

        //Product Page #2
        ProductPage productPage = new ProductPage(Page);
        List<double> PriceList = new List<double>(); //List to get product price     
        await productPage.GetPriceList(PriceList);    
        
        //Sort the products by Price (high to low)
        await productPage.HighToLowFilter();
        List<double> PriceListwithfilter = new List<double>(); //List to get price after filtered
        await productPage.GetPriceList(PriceListwithfilter);  

        //Assertion for filter
        await productPage.AssertionForFilter(PriceList,PriceListwithfilter);

        //Add Cheapest 3 products to cart
        await productPage.AddCheapest3of(PriceListwithfilter);

        //Assert three products have been added to cart
        await productPage.AssertionForCartCount();

        //Go To checkout
        await productPage.ClickOnCart();

        //Your Cart Page #3
        YourCartPage yourCartPage = new YourCartPage(Page);

        //Get list of products in the cart
        List<double> PriceListinCart = new List<double>();
        await productPage.GetPriceList(PriceListinCart);

        //Remove The cheapest product in the cart
        await yourCartPage.RemoveCheapestOne(PriceListinCart);

        //Go to Add details section
        await yourCartPage.GotoAddDetailsSection();

        //Add Details to the fields
        UserInfoPage userInfoPage = new UserInfoPage(Page);
        await userInfoPage.FillDetails("Saruga","Satgunarajah","40000");

        //Go to OverView
        await userInfoPage.GoToOverview();

        //OverView Page #4
        Overviewpage overviewpage = new Overviewpage(Page);

        //Finish Purchase
        await overviewpage.FinishPurchase();

         //Assert for Purchase Complete
         await Expect(Page.GetByText("Thank you for your order!")).ToBeVisibleAsync();

    }

}
