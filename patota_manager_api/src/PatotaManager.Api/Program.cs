using Microsoft.EntityFrameworkCore;
using patota_manager_api.src.PatotaManager.Common.Helpers;
using patota_manager_api.src.PatotaManager.Infrastructure.Data;
using patota_manager_api.src.PatotaManager.Infrastructure.Mappings;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories;
using patota_manager_api.src.PatotaManager.Infrastructure.Repositories.Interfaces;


var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter("dd/MM HH:mm"));
});

builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ApiDbContext>();

builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IUsersRepository, UsersRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

