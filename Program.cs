using MetaenlaceNet.Repository;
using MetaenlaceNet.Service;
using MetaenlaceNet.Entity;
using Microsoft.EntityFrameworkCore;
using MetaenlaceNet.Mapper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("METAENLACE_HOSP");
builder.Services.AddDbContext<EntityContext>(
   options => options.UseSqlServer("name=METAENLACE_HOSP:DefaultConnection")
  ) ;
builder.Services.AddScoped<PacienteRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<CitaRepository>();
builder.Services.AddScoped<DiagnosticoRepository>();
builder.Services.AddScoped<MedicoRepository>();

builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IDiagnosticoService, DiagnosticoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAutoMapper(typeof(CitaMapper), typeof(DiagnosticoMapper)
    , typeof(MedicoMapper), typeof(PacienteMapper));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<EntityContext>();
    db.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
