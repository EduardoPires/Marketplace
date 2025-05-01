using Marketplace.Dominio.Servicos.Comum;
using Marketplace.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
BootStrapper.Register(builder.Services);
builder.Services.AddControllersWithViews();
builder.Services.Configure<FormOptions>(options =>
{
    options.ValueLengthLimit = int.MaxValue;  // Define o limite de tamanho do arquivo (em bytes)
    options.MultipartBodyLengthLimit = int.MaxValue;  // Define o limite de tamanho do corpo multipart
});
var app = builder.Build();
builder.Logging.AddConsole();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
