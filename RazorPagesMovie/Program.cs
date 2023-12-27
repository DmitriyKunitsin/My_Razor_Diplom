using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesMovie.Data;
using RazorPagesMovie.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));
builder.Services.AddDbContext<RazorPagesMovieContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
} else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolContext>();
    DbInitializer.Initialize(context);
}
app.UseHttpsRedirection();
//�������������� ��� ������� HTTP �� HTTPS.
app.UseStaticFiles();
//������������ ������������ ����� ����������� ������, ��� HTML, CSS, ����������� � JavaScript.
app.UseRouting();
//��������� ������������ �������� � �������� �� �������������� ����.
app.UseAuthorization();
//��������� ������������ ������ � ���������� ��������. ��� ���������� �� ���������� �����������, ������� ��� ������ ����� �������.
app.MapRazorPages();
//����������� ������������� �������� ����� ��� Razor Pages.
app.Run();
//�������� ����������