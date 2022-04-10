using Microsoft.EntityFrameworkCore;
using TeamTech.ORM.Entities;
using TeamTech.RestAPI.Service;

var builder = WebApplication.CreateBuilder(args);
string dbsource = "UserID=postgres;Password=root;Server=localhost;Port=5432;Database=teamtech;IntegratedSecurity=true;Pooling=true;";
// Add services to the container.


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<BloggingContext>()
    .AddScoped<BloggingService>()
    .AddScoped<BloggingContext>()
    .AddDbContext<BloggingContext>(o =>
    {
        o.UseNpgsql(dbsource, x=>x.MigrationsAssembly("TeamTech.RestAPI"));
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else { 
    app.UseDeveloperExceptionPage();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<BloggingContext>();
    //context.Database.EnsureCreated();
    // DbInitializer.Initialize(context);
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
