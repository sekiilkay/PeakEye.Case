using Microsoft.AspNetCore.Identity;
using PeakEye.Repository.Context;
using PeakEye.Repository.Extensions;
using PeakEye.Repository.Users;
using PeakEye.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositoryExtension(builder.Configuration)
                .AddServiceExtension(builder.Configuration);

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<PeakEyeContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthorization();

app.MapControllers();

app.Run();
