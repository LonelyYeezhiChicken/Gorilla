using API.SDK;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IChatGpt>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var uri = "https://api.openai.com/v1/completions"; // 您可以替換為適當的 URI

    return new ChatGpt(httpClientFactory, uri);
});


var app = builder.Build();



Console.WriteLine(@"
 ________  ________  ________  ___  ___       ___       ________          ________  ________  _________   
|\   ____\|\   __  \|\   __  \|\  \|\  \     |\  \     |\   __  \        |\   ____\|\   __  \|\___   ___\ 
\ \  \___|\ \  \|\  \ \  \|\  \ \  \ \  \    \ \  \    \ \  \|\  \       \ \  \___|\ \  \|\  \|___ \  \_| 
 \ \  \  __\ \  \\\  \ \   _  _\ \  \ \  \    \ \  \    \ \   __  \       \ \  \  __\ \   ____\   \ \  \  
  \ \  \|\  \ \  \\\  \ \  \\  \\ \  \ \  \____\ \  \____\ \  \ \  \       \ \  \|\  \ \  \___|    \ \  \ 
   \ \_______\ \_______\ \__\\ _\\ \__\ \_______\ \_______\ \__\ \__\       \ \_______\ \__\        \ \__\
    \|_______|\|_______|\|__|\|__|\|__|\|_______|\|_______|\|__|\|__|        \|_______|\|__|         \|__|
                                                                                                          
");


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
