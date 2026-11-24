
using CMS.Data.EntityFrameworkCore;
using CMS.Infrastructure.Middlewares;
using CMS.Infrastructure.Services;
using CMS.Infrastructure.Services.Categories;
using Data;
using Data.Models;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Infrastructure.Services.Tracks;
using InfraStructure.Mapping;
using InfraStructure.Services;
using InfraStructure.Services.Advertisement;
using InfraStructure.Services.Notifications;
using InfraStructure.Services.Posts;
using InfraStructure.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<CMSDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<CMSDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAdvertisementService, AdvertisementService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ITrackService, TrackService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<INotificationService, NotificationService>();
builder.Services.AddTransient<IDashboardService, DashboardService>();
builder.Services.AddAutoMapper(cfg => { }, typeof(MapperProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseExceptionHandler(opts => opts.UseMiddleware<ExceptionHandler>());
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();


if (FirebaseApp.DefaultInstance == null)
{
    FirebaseApp.Create(new AppOptions
    {
        Credential = GoogleCredential.FromFile(
            Path.Combine(app.Environment.ContentRootPath, "cmsweb-23be2-firebase-adminsdk-fbsvc-aeafee542f.json"))
    });
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
