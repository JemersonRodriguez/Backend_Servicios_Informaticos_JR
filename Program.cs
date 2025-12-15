using Backend_SSR_Servicios_Informaticos_JR.Data;
using Backend_SSR_Servicios_Informaticos_JR.Services;
using Microsoft.EntityFrameworkCore;
using Resend;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
#region Registro de Servicios
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IEnviarCorreoService, EnviarCorreoService>();

// MVC
builder.Services.AddControllersWithViews();

// Opciones (necesarias)
builder.Services.AddOptions();

// HttpClient que Resend usa internamente
builder.Services.AddHttpClient<ResendClient>();

// Configuración del cliente
builder.Services.Configure<ResendClientOptions>(options =>
{
    options.ApiToken =
        builder.Configuration["Resend:ApiKey"] ?? Environment.GetEnvironmentVariable("RESEND_APITOKEN");
});

// Registro DI
builder.Services.AddTransient<IResend, ResendClient>();
builder.Services.AddDbContext<ApplicationDbContext>(options=> { 
    options.UseSqlServer(connectionString);
});


//End Services

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/LandingPage/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=LandingPage}/{action=Index}/{id?}");

app.Run();
