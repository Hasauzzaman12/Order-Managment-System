using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OMS.Interface;
using OMS.Repository;
using OMS.Data;
using System.Xml.Linq;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddScoped<IDepartment,DepartmentRepository>();
builder.Services.AddScoped<IDesignation,DesignationRepository>();
builder.Services.AddScoped<ICompany,CompanyRepository>();
builder.Services.AddScoped<IEmployee,EmployeeRepository>();
builder.Services.AddScoped<IModule,ModuleRepository>();
builder.Services.AddScoped<IUoM,UoMRepository>();
builder.Services.AddScoped<ICategory,CategoryRepository>();
builder.Services.AddScoped<IProduct,ProductRepository>();
builder.Services.AddScoped<IBuyer,BuyerRepository>();
builder.Services.AddScoped<IBrand,BrandRepository>();
builder.Services.AddScoped<ICsPerson,CsPersonRepository>();
builder.Services.AddScoped<ICustomer,CustomerRepository>();
builder.Services.AddScoped<IOrderMaster,OrderMasterRepository>();
builder.Services.AddScoped<IOrderType,OrderTypeRepository>();
builder.Services.AddScoped<IMainMenu,MainMenuRepository>();
builder.Services.AddScoped<ISubMenu,SubMenuRepository>();
builder.Services.AddScoped<IMenu,MenuRepository>();

//Add Login
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "areas",
      pattern: "{area=Settings}/{controller=Module}/{action=Landing}/{id?}");

app.MapRazorPages();

app.Run();
