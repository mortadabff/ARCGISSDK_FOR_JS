# Main concepts related to .NET core mvc , and how it works !
## How "Program.cs" works ? and what it does?
The Program.cs file in an ASP.NET Core application configures the application's web host and sets up the middleware pipeline that handles HTTP requests. 
Here how the pipeline works step by step:
-  "var builder = WebApplication.CreateBuilder(args)":
WebApplication.CreateBuilder: This initializes a new instance of the WebApplicationBuilder class, which is used to configure services and the application's request pipeline.
-   "builder.Services.AddControllersWithViews()" :
builder.Services.AddControllersWithViews(): This method adds the necessary services for MVC (Model-View-Controller) pattern, which includes controllers and views. It registers the MVC framework services in the dependency injection (DI) container.

- " var app = builder.Build()":
builder.Build(): This builds the WebApplication object, which represents the configured application. This method finalizes the configuration of the services and prepares the application to handle HTTP requests.
- The following lines configure the middleware pipeline, which is a sequence of components that process HTTP requests and responses.
* "if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
"
Environment Check: If the application is not in development mode, the middleware for handling exceptions and HSTS (HTTP Strict Transport Security) is added.

app.UseExceptionHandler("/Home/Error"): This middleware catches exceptions and shows an error page located at /Home/Error.

app.UseHsts(): This middleware adds the HSTS header to responses. HSTS tells browsers to only use HTTPS for future requests to the site.

-  "app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();"

"HTTPS Redirection: app.UseHttpsRedirection() redirects HTTP requests to HTTPS.
Static Files: app.UseStaticFiles() enables serving static files (e.g., HTML, CSS, images) from the wwwroot folder.
Routing: app.UseRouting() adds routing middleware to the pipeline. This middleware analyzes the request URL and matches it to the defined routes.
Authorization: app.UseAuthorization() adds authorization middleware to the pipeline, which ensures that the user is authorized to access resources."

- Define endpoints : 
* "app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");"

 This line defines a default route for the application using the MVC pattern. The route pattern {controller=Home}/{action=Index}/{id?} specifies that the default controller is Home and the default action is Index, with an optional id parameter.


- finally run the application :   app.Run() starts the application and listens for incoming HTTP requests.

 *  "app.Run();"


