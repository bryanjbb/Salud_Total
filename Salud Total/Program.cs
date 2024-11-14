using Salud_Total.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductoServices>();
builder.Services.AddScoped<PresentacionServices>();
builder.Services.AddScoped<CompraServices>();
builder.Services.AddScoped<Detalle_VentaServices>();
builder.Services.AddScoped<Detalle_CompraServices>();
builder.Services.AddScoped<VentaServices>();
builder.Services.AddScoped<LaboratorioServices>();
var app = builder.Build();
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
