using Marketplace.Dominio.Interfaces.Servicos;
using Marketplace.Aplicacao;
using Marketplace.Dominio.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Marketplace.Aplicacao.Interfaces;
using Marketplace.Dominio.Interfaces.Repositorio;
using Marketplace.Infra.Repositorio.EntityFramework;
using Marketplace.Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Marketplace.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(IServiceCollection services, IWebHostEnvironment environment)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<EFDbContext>();

            var caminhoBanco = Path.Combine(Directory.GetCurrentDirectory(), "app.db");

            if (environment.IsDevelopment())
                services.AddDbContext<EFDbContext>(options => options.UseSqlite($"Data Source={caminhoBanco}"));
            else
                services.AddDbContext<EFDbContext>(options => options.UseSqlServer("Server=localhost;Database=Marketplace;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;"));

            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IProdutoService, ProdutoServico>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<ICategoriaService, CategoriaServico>();
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();

            services.AddScoped<IVendedorAppService, VendedorAppService>();
            services.AddScoped<IVendedorService, VendedorServico>();
            services.AddScoped<IVendedorRepositorio, VendedorRepositorio>();


        }
    }
}
