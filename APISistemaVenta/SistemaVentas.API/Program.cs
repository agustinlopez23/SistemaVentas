using SistemaVenta.IOC;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InyectarDependendencias(builder.Configuration);
builder.Services.AddCors(options => { options.AddPolicy("New policy", app =>
{
    app.AllowAnyOrigin();
    app.AllowAnyMethod();
    app.AllowAnyHeader();
})});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("New policy");
app.UseAuthorization();

app.MapControllers();

app.Run();
