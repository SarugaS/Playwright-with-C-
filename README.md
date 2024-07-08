# Playwright with C#
This repository is having Automation test scripts of webpage using Playwright with C#
Following Steps are done in Automation
1. **Go to the following URL: https://www.saucedemo.com/**
2. **log in as a standard user.**
3. **Automating the following scenario.**
   - Sort the products by Price (high to low)
   - Add the three cheapest products to your basket from UI.
   - Open the basket.
   - Remove the cheapest product from your basket.
   - Enter your name and postal code.
   - Complete the purchase.

**Browser configurations are not done and It can be achived with CLI command**
  
  - **To run in headless mode:** `$env:HEADED="1">> dotnet test`
  - **To debug the code:** `await page.PauseAsync();` or CLI Command: `pwsh bin/Debug/net8.0/playwright.ps1 codegen saucedemo.com`

**Reference**

- https://playwright.dev/dotnet/docs/intro
- https://www.youtube.com/watch?v=5i53YLWD_QI&list=PL6tu16kXT9PoUv6HwexX5LPBzzv7QkI9W&pp=iAQB

  

