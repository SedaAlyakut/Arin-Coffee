using Buisness.Abstract;
using Buisness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WEBUI.Entities;
using WEBUI.Entities.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<ICardService, CardManager>();
builder.Services.AddSingleton<ICardDal, EfCardDal>();
builder.Services.AddSingleton<ICommentService, CommentManager>();
builder.Services.AddSingleton<ICommentDal, EfCommentDal>();
builder.Services.AddSingleton<IFeedBackService, FeedBackManager>();
builder.Services.AddSingleton<IFeedBackDal, EfFeedBackDal>();
builder.Services.AddSingleton<IOrderService, OrderManager>();
builder.Services.AddSingleton<IOrderDal, EfOrderDal>();
builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, EfProductDal>();
builder.Services.AddSingleton<IUserServicecs, UserManager>();
builder.Services.AddSingleton<IUserDal, EfUserDal>();
builder.Services.AddSingleton<IWatchService, WatchManager>();
builder.Services.AddSingleton<IWatchDal, EfWatchDal>();
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyData")));

builder.Services.AddIdentity<CustomIdentityUser, CustomIdentityRole>(_ =>
{
    _.Password.RequiredLength = 5; //En az kaç karakterli olmasý gerektiðini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunluluðunu kaldýrýyoruz.
    _.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldýrýyoruz.
    _.Password.RequireUppercase = false; //Büyük harf zorunluluðunu kaldýrýyoruz.
    _.Password.RequireDigit = false; //0-9 arasý sayýsal karakter zorunluluðunu kaldýrýyoruz.
    _.User.RequireUniqueEmail = true; //Email adreslerini tekilleþtiriyoruz.
    _.User.AllowedUserNameCharacters = "abcçdefghiýjklmnoöpqrsþtuüvwxyzABCÇDEFGHIÝJKLMNOÖPQRSÞTUÜVWXYZ0123456789-._@+"; //Kullanýcý adýnda geçerli olan karakterleri belirtiyoruz.
}).AddPasswordValidator<CustomPasswordValidation>()
     .AddUserValidator<CustomUserValidation>()
     .AddErrorDescriber<CustomIdentityErrorDescriber>().AddEntityFrameworkStores<CustomIdentityDbContext>()
     .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(_ =>
{
    _.LoginPath = new PathString("/Account/Login");
    _.LogoutPath = new PathString("/Account/LogOff");
    _.Cookie = new CookieBuilder
    {
        Name = "AspNetCoreIdentityExampleCookie", //Oluþturulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //Kötü niyetli insanlarýn client-side tarafýndan Cookie'ye eriþmesini engelliyoruz.
        //Expiration = TimeSpan.FromMinutes(20), //Oluþturulacak Cookie'nin vadesini belirliyoruz.
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin gönderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS üzerinden eriþilebilir yapýyoruz.
    };
    _.SlidingExpiration = true; //Expiration süresinin yarýsý kadar süre zarfýnda istekte bulunulursa eðer geri kalan yarýsýný tekrar sýfýrlayarak ilk ayarlanan süreyi tazeleyecektir.
    _.ExpireTimeSpan = TimeSpan.FromMinutes(20); //CookieBuilder nesnesinde tanýmlanan Expiration deðerinin varsayýlan deðerlerle ezilme ihtimaline karþýn tekrardan Cookie vadesi burada da belirtiliyor.
    _.AccessDeniedPath = new PathString("/Account/Login");
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
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |
    ForwardedHeaders.XForwardedProto
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
