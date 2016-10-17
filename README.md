# [stormpath-aspnetcore-stripe-example](LINK)
Build a secure web application using Stormpath, Stripe, and ASP.NET Core. Clone it and kick the tires!

If you want step-by-step instructions, check out the [stormpath-aspnetcore-stripe-example](LINK).

## Getting started

1. **[Sign up](https://api.stormpath.com/register) for Stormpath**
2. **Get your API credentials**

  i. Log in to the [Stormpath Admin Console](https://api.stormpath.com/login).
  
  ii. Click the Create API Key or Manage Existing Keys under Developer Tools on the right side of the page.
  
  iii.Scroll down to Security Credentials and click Create API Key. This will generate your API Key and download it to your computer as an apiKey.properties file.
  
  iv. Go to “Groups” tab and click on “Create Group” button, and create a group called **'Premium'***.

3. **Store your key as environment variables**

  Open your key file and grab the **API Key ID** and **API Key Secret**, then run these commands in PowerShell (or the Windows Command Prompt) to save them as environment variables:

  ```

  setx STORMPATH_CLIENT_APIKEY_ID "[value from properties file]"
  setx STORMPATH_CLIENT_APIKEY_SECRET "[value from properties file]"

  ```

4. **Store your Stormpath Application href in an environment variable**

  Grab the ```href``` (called **REST URL** in the Stormpath Console UI) of your Application. It should look something like this:

  https://api.stormpath.com/v1/applications/q42unYAj6PDLxth9xKXdL

  Save this as an environment variable:

  ```
  setx STORMPATH_APPLICATION_HREF "[your Application href]"
  ```

5. **[Sign up](https://stripe.com/) for Stripe**

6. **Get your Stripe API credentials**

  Go to your `account > account settings > API Keys` and write down your test API keys. 
  Once you open the solution in Visual Studio, store them using **User secrets** by right-clicking on your web application and then click on “Manage User Secrets".

  ``` 
  “PaymentSettings:StripePublicKey”:”your_stripe_public_key”
  “PaymentSettings:StripePrivateKey”:”your_stripe_private_key”
  ```

7. **Clone this repository**

  ``` 
  git clone https://github.com/stormpath/stormpath-aspnetcore-stripe-example.git
  ```

8. **Build and Run**

  cd stormpath-aspnetcore-stripe-example
  cd src/stormpathWebAppDemo
  dotnet restore
  dotnet run

Once you have the site up, click on register to create a new user!
