using Microsoft.EntityFrameworkCore;
using SaaSVet.Contexts.Register.Application.DeletePetUseCase;
using SaaSVet.Contexts.Register.Application.NewOwnerUseCase;
using SaaSVet.Contexts.Register.Application.NewPetUseCase;
using SaaSVet.Contexts.Register.Domain.IRepositories;
using SaaSVet.Contexts.Register.Infrastructure.Persistance;
using SaaSVet.Contexts.Register.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "server=localhost;database=saasvet;user=root;password=";

builder.Services.AddDbContext<AppointmentsDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetOwnerRepository, OwnerRepository>();
builder.Services.AddScoped<NewPetUseCase>();
builder.Services.AddScoped<NewOwnerUseCase>();
builder.Services.AddScoped<DeletePetUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();