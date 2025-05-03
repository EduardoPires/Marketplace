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

namespace Marketplace.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<EFDbContext>();

            services.AddDbContext<EFDbContext>(options => options.UseSqlite("Data Source=app.db"));
            //services.AddDbContext<EFDbContext>(options => options.UseSqlServer("Server=localhost;Database=Marketplace;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;"));

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
