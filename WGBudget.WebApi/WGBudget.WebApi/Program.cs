using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WGBudget.Data;
using WGBudget.Data.Repositories;
using WGBudget.Services;
using Microsoft.AspNetCore.Identity.UI;
using static Dapper.SqlMapper;

var builder = WebApplication.CreateBuilder(args);


// Setup DbContext
var connectionString = builder.Configuration
    .GetConnectionString("SqlConnection")
        ?? throw new InvalidOperationException("Connection string 'SqlConnection' not found.");

var masterString = builder.Configuration
    .GetConnectionString("MasterConnection")
        ?? throw new InvalidOperationException("Connection string 'MasterConnection' not found.");

builder.Services.AddDbContext<IdentityDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("MasterConnection"),
            x => x.MigrationsAssembly("WGBudget.Data")));


// Add services to the container.
builder.Services
    .Configure<RouteOptions>(options =>
    {
        options.LowercaseUrls = true;
    });

builder.Services
    .AddControllersWithViews();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<DapperDataContext>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ITransactionCategoryRepository, TransactionCategoryRepository>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddDefaultIdentity<IdentityUser<int>>
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
.AddEntityFrameworkStores<IdentityDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
