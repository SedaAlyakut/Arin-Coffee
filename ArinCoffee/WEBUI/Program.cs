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
    _.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
    _.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
    _.Password.RequireLowercase = false; //K���k harf zorunlulu�unu kald�r�yoruz.
    _.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
    _.Password.RequireDigit = false; //0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.
    _.User.RequireUniqueEmail = true; //Email adreslerini tekille�tiriyoruz.
    _.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+"; //Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.
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
        Name = "AspNetCoreIdentityExampleCookie", //Olu�turulacak Cookie'yi isimlendiriyoruz.
        HttpOnly = false, //K�t� niyetli insanlar�n client-side taraf�ndan Cookie'ye eri�mesini engelliyoruz.
        //Expiration = TimeSpan.FromMinutes(20), //Olu�turulacak Cookie'nin vadesini belirliyoruz.
        SameSite = SameSiteMode.Lax, //Top level navigasyonlara sebep olmayan requestlere Cookie'nin g�nderilmemesini belirtiyoruz.
        SecurePolicy = CookieSecurePolicy.Always //HTTPS �zerinden eri�ilebilir yap�yoruz.
    };
    _.SlidingExpiration = true; //Expiration s�resinin yar�s� kadar s�re zarf�nda istekte bulunulursa e�er geri kalan yar�s�n� tekrar s�f�rlayarak ilk ayarlanan s�reyi tazeleyecektir.
    _.ExpireTimeSpan = TimeSpan.FromMinutes(20); //CookieBuilder nesnesinde tan�mlanan Expiration de�erinin varsay�lan de�erlerle ezilme ihtimaline kar��n tekrardan Cookie vadesi burada da belirtiliyor.
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
