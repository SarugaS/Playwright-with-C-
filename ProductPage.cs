using Microsoft.Playwright;
namespace PlaywrightTests.Pages;

public class ProductPage{
    private IPage _page;
    private readonly ILocator _btnFilter; 
    private readonly ILocator _btnAddtoCart; 
    private readonly ILocator _btnRemove;
    private readonly ILocator _btnCart;

    //Idetify the page elements
    public ProductPage(IPage page)
    {
        _page = page;
        _btnFilter = _page.Locator("[data-test=\"product-sort-container\"]");
        _btnAddtoCart = _page.GetByText("Add to cart");
        _btnRemove = _page.GetByText("Remove");
        _btnCart = _page.Locator("[data-test=\"shopping-cart-link\"]");

    }

    //Filter Products by High to Low
    public async Task HighToLowFilter() => await _btnFilter.SelectOptionAsync("hilo");  

    //Get a list of product price list
    public async Task GetPriceList(List<double> List)
    {
        var elements = await _page.QuerySelectorAllAsync("[data-test='inventory-item-price']");
        // Iterate over elements and add numbers to the list
        foreach (var element in elements)
            {
                // Get text content of each element
                var text = await element.TextContentAsync();
                if (!string.IsNullOrEmpty(text) && text.Length > 1)
                {
                    //removing the '$' sign from the text to get only the price
                    var WithoutFirstLetter = text.Substring(1);
                    //convert the string to double
                    if (double.TryParse(WithoutFirstLetter, out double number))
                        {
                            List.Add(number);
                        }
                
                }
            }
    }

    //Assertion for the filter
    public async Task AssertionForFilter(List<double> list1, List<double> list2)
    {
        list1.Sort((a, b) => b.CompareTo(a));
        for (int i = 0; i < list1.Count; i++)
        {
            if (list1[i] != list2[i])
            {
                break;
            }
            continue;
        }
        await Task.Delay(2000);
    }


    //Add the three cheapest products to basket from UI
    public async Task AddCheapest3of(List<double> List)
    {
        var count = List.Count();
        for (int i = count-1; i >=(count-3); --i)
            await _btnAddtoCart.Nth(i).ClickAsync();  
    }

    //Assert three products have been added to cart
    public async Task AssertionForCartCount()
    {
        var carttext= await _btnCart.TextContentAsync();
        Assert.That(carttext, Is.EqualTo("3"));
    }

    //Click on cart to Checkcout
    public async Task ClickOnCart() => await _btnCart.ClickAsync();  


}