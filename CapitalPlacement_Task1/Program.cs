using CapitalPlacement_Task1.Infrastructure;
using CapitalPlacement_Task1.Infrastructure.Persistence;
using CapitalPlacement_Task1.Services;
using CapitalPlacement_Task1.Services.Interfaces.Repository;
using CapitalPlacement_Task1.Services.Interfaces.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DbContext>();
//repositories
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
//services
builder.Services.AddScoped<ICreateProgramService,CreateProgramService>();
builder.Services.AddScoped<IGetProgramService,GetProgramService>();
builder.Services.AddScoped<IUpdateProgramService,UpdateProgramService>();
builder.Services.AddScoped<IDeleteProgramService,DeleteProgramService>();

builder.Services.AddControllers();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
