using Microsoft.EntityFrameworkCore;
using SaaSVet.Common.Persistance;
using SaaSVet.Contexts.Appoitment.Application.CancelAppointmentUseCase;
using SaaSVet.Contexts.Appoitment.Application.CreateAppointmentUseCase;
using SaaSVet.Contexts.Appoitment.Application.ViewPetAppointmentsUseCase;
using SaaSVet.Contexts.Appoitment.Domain.IRepositories;
using SaaSVet.Contexts.Appoitment.Infrastructure.Repositories;
using SaaSVet.Contexts.Register.Application;
using SaaSVet.Contexts.Register.Application.DeletePetUseCase;
using SaaSVet.Contexts.Register.Application.NewOwnerUseCase;
using SaaSVet.Contexts.Register.Application.NewPetUseCase;
using SaaSVet.Contexts.Register.Application.ShowOwnedPetsUseCase;
using SaaSVet.Contexts.Register.Domain.IRepositories;
using SaaSVet.Contexts.Register.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
                       ?? "server=localhost;database=saasvet;user=root;password=";

builder.Services.AddDbContext<VetDbCotnext>(options =>
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
builder.Services.AddScoped<ShowOwnedPetsUseCase>();
builder.Services.AddScoped<ShowOwnersUseCase>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<CancelAppointmentUseCase>();
builder.Services.AddScoped<CreateAppointmentUseCase>();
builder.Services.AddScoped<ViewPetAppointmentsUseCase>();

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy((policy =>
        {
            policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
        }));
    });

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();