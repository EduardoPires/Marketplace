using Marketplace.Infra.CrossCutting.IoC;


    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddRazorPages();
    // Add services to the container.
    BootStrapper.Register(builder.Services, builder.Environment);

    builder.Services.AddControllersWithViews();
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

    app.UseAuthorization();
    app.UseAuthentication();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    app.MapRazorPages();
    app.Run();
