using Microsoft.Playwright;

public class LoginPage{
    private IPage _page;
    private readonly ILocator _txtUserName; 
    private readonly ILocator _txtPassword;
    private readonly ILocator _btnLogin;

    //Idetify the page elements
    public LoginPage(IPage page)
    {
        _page = page;
        _txtUserName = _page.GetByPlaceholder("Username");
        _txtPassword = _page.GetByPlaceholder("Password");
        _btnLogin = _page.Locator("[data-test=\"login-button\"]");

    }

    //login through the login page
    public async Task Login(String Username, String Password)
    {
        await _txtUserName.ClickAsync();
        await _txtUserName.FillAsync(Username);
        await _txtPassword.ClickAsync();
        await _txtPassword.FillAsync(Password);
        await _btnLogin.ClickAsync();
    }

    //Assertion after login
    public async Task AssertLogin() => await _page.GetByText("Products").IsVisibleAsync();

}