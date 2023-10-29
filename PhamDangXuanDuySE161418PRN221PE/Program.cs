
using Application;
using Domain.Entity;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CartoonFilm2023DBContext>();
builder.Services.AddScoped<IAccountRepo,AccountRepository>();
builder.Services.AddScoped<ICartoonRepo,CartonRepository>();
builder.Services.AddScoped<IProducerRepo,ProducerRepository>();
builder.Services.AddScoped<IMemeberService,MemberService>();
builder.Services.AddScoped<IProducerService,ProducerSerivce>();
builder.Services.AddScoped<ICartonService,CartoonService>();
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
