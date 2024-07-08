using Microsoft.Playwright;

public class UserInfoPage{
    private IPage _page;
    private readonly ILocator _txtFirstName; 
    private readonly ILocator _txtLastName;
    private readonly ILocator _txtPostalCode;
    private readonly ILocator _btnContinue;
    private readonly ILocator _btnCancel;

    //Idetify the page elements
    public UserInfoPage(IPage page)
    {
        _page = page;
        _txtFirstName = _page.GetByPlaceholder("First Name");
        _txtLastName = _page.GetByPlaceholder("Last Name");
        _txtPostalCode = _page.GetByPlaceholder("Zip/Postal Code");
        _btnContinue = _page.Locator("[id=\"continue\"]");
        _btnCancel = _page.Locator("[id=\"cancel\"]");

    }

    //Add personal details for purchase
    public async Task FillDetails(String FirstName,String LastName,String PostalCode)
    {
        await _txtFirstName.ClickAsync();
        await _txtFirstName.FillAsync(FirstName);
        await _txtLastName.ClickAsync();
        await _txtLastName.FillAsync(LastName);
        await _txtPostalCode.ClickAsync();
        await _txtPostalCode.FillAsync(PostalCode);
    }

    //Go to OverView
    public async Task GoToOverview() => await _btnContinue.ClickAsync();

}