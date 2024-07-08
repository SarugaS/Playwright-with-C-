using Microsoft.Playwright;

public class Overviewpage{
    private IPage _page;
    private readonly ILocator _btnFinish;
    private readonly ILocator _btnCancel;

    //Idetify the page elements
    public Overviewpage(IPage page)
    {
        _page = page;
        _btnFinish = _page.Locator("[id=\"finish\"]");
        _btnCancel = _page.Locator("[id=\"cancel\"]");

    }


    //Finish Purchase
    public async Task FinishPurchase() => await _btnFinish.ClickAsync();
    

}