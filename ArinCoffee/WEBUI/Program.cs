using Buisness.Abstract;
using Buisness.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
