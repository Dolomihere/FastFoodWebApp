using Assignment_NET104.DataContext;
using Assignment_NET104.Services;
using Assignment_NET104.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add ef core
builder.Services.AddDbContext<WebContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

// Dependence Injection
builder.Services.AddScoped<IAdmin, Adminsvc>();
builder.Services.AddScoped<ICart, Cartsvc>();
builder.Services.AddScoped<ICustomer, Customersvc>();
builder.Services.AddScoped<IFileImage, Imagesvc>();
builder.Services.AddScoped<IFoodItem, FoodItemsvc>();
builder.Services.AddScoped<IOrder, Ordersvc>();

// Add authentication & authorization
builder.Services.AddScoped<IUser, Usersvc>();
builder.Services.AddAuthentication("Login")
    .AddCookie("Login", o =>
    {
        o.Cookie.Name = "UserInfo";
        o.LoginPath = "/Account/Login";
        o.AccessDeniedPath = "/AccessDenied";
    });
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("AdminAccess", p => p.RequireRole("Admin"));
    o.AddPolicy("CustomerAccess", p => p.RequireRole("Customer"));
});

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Menu}/{action=Home}/{id?}");

app.Run();
