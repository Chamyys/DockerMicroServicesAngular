using ProjectInfoTecs.ApplicationEntityGenerator;
using ProjectInfoTecs.ItemService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IItemService, ItemService>();
builder.Services.AddControllersWithViews();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Разрешение запросов от фронта
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
builder.WebHost.UseUrls("http://*:5000");
var app = builder.Build();
var itemService = app.Services.GetRequiredService<IItemService>();

ApplicationEntityGenerator generator = new ApplicationEntityGenerator();
int i = 0;

var timer = new Timer(_ => //Генерация объектов
{
  
    itemService.AddItem(generator.getNewEntity());
}, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 
app.UseRouting();

app.UseCors("AllowAngApp");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

