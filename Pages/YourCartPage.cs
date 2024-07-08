using Microsoft.Playwright;

public class YourCartPage{
    private IPage _page;
    private readonly ILocator _btnRemove; 
    private readonly ILocator _btnCheckout;
    private readonly ILocator _btnContinueShopping;

    //Idetify the page elements
    public YourCartPage(IPage page)
    {
        _page = page;
        _btnRemove = _page.GetByText("Remove");
        _btnCheckout = _page.GetByText("Checkout");
        _btnContinueShopping = _page.Locator("[data-test=\"continue-shopping\"]");;

    }

    //Removing the Cheapest one from the cart
    public async Task RemoveCheapestOne(List<double> list)
    {
        list.Sort();
        var CheapestPrice = list[0];
        String cheapest = CheapestPrice.ToString();
        await _page.Locator("[data-test=\"inventory-item\"]").Filter(new() { HasText = cheapest }).GetByRole(AriaRole.Button, new() { Name = "Remove" }).ClickAsync();
    }

    //Go to Add details Section
    public async Task GotoAddDetailsSection() => await _btnCheckout.ClickAsync();

}