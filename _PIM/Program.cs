using _PIM.Data;
using _PIM.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao contêiner.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddHttpClient<WeatherService>();

// Configuração do serviço de banco de dados
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DbPath")));

// Configuração do Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Adiciona suporte a sessões
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Middleware para criação de papéis e usuário admin
async Task CreateRoles(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Defina os papéis que queremos garantir que existam
    string[] roleNames = { "Admin", "User" };
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    // Criar um usuário Admin padrão, caso não exista
    var adminUser = await userManager.FindByEmailAsync("admin@example.com");
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = "admin@example.com",
            Email = "admin@example.com"
        };
        await userManager.CreateAsync(adminUser, "Admin@123");
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

// Configuração do pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Middleware de autenticação, autorização e sessão
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); // Ativação do suporte a sessões

// Mapeamento de rotas
app.MapControllerRoute(
    name: "loja",
    pattern: "Loja",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "dashboard_produtos",
    pattern: "Dashboard/Produtos",
    defaults: new { controller = "Produto", action = "Index" });

app.MapControllerRoute(
    name: "dashboard",
    pattern: "Dashboard",
    defaults: new { controller = "Admin", action = "Index" });

app.MapControllerRoute(
    name: "dashboard_sensores",
    pattern: "Dashboard/Sensores",
    defaults: new { controller = "Sensor", action = "Index" });

app.MapControllerRoute(
    name: "entrar",
    pattern: "Entrar",
    defaults: new { controller = "Account", action = "Login" });

app.MapControllerRoute(
    name: "criar_conta",
    pattern: "CriarConta",
    defaults: new { controller = "Account", action = "Register" });

app.MapControllerRoute(
    name: "pagamento",
    pattern: "pagamento",
    defaults: new { controller = "Pagamento", action = "Index" });

// Rota padrão para controllers
app.MapDefaultControllerRoute();

// Executa a criação dos papéis e do usuário admin
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await CreateRoles(services);
}

app.Run();
