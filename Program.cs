using Internal_Resource_Booking_System.Data;
using Microsoft.EntityFrameworkCore;

//creates a web application builder that sets app's services
var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Registers support for Razor Pages
builder.Services.AddRazorPages();

//Dependency Injection
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionToDbServer")));
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); //Http to Https
app.UseStaticFiles();      //Javascript, Images

app.UseRouting();

app.UseAuthorization(); 

app.MapRazorPages();    //Map Razor Pages

app.Run();              //Starts Http server
