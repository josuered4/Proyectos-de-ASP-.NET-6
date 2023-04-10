using portafolio.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRepositorioProyectos, RepositorioProyectos>();//añadimos la clase en servicios para ser inyectado
//Cuando se pida un IRepositorioProyectos se le mande una instancia de RepositorioProyectos"que hereda de la interfaz"
//AHORA BIEN SOLO SE REQUIERE UNA CLASE QUE IMPLEMENTE EL REPOSITORIO, PUEDE SER ESTA U OTRA PERO QUE LO IMPLEMENTE 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
