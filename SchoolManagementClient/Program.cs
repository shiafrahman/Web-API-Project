using SchoolManagementClient.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<StudentService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5116");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=students}/{action=Index}/{id?}");

app.Run();
