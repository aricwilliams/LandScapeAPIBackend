using LandScapeAPI.Models;
using LandScapeAPI.Repo;
using LandScapeAPI.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LandScapeAPI", Version = "v1"});
});
builder.Services.AddDbContext<ProductDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped < IProductRepository, ProductRepository> ();
builder.Services.AddScoped<IJobs, Jobs> ();
builder.Services.AddScoped<IInvoice, Invoice>();
builder.Services.AddScoped<IChatMessage, ChatMessage>();

builder.Services.Configure<EmailMessage>(builder.Configuration.GetSection(nameof(EmailMessage)));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository> ();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ProductDbContext>();
builder.Services.AddTransient<IMailService, MailService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LandScapeAPI v1"));
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
