var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy(name: "cors",
                    policy =>
                    {
                        policy.WithOrigins("https://prueba.agenciareforma.com", "http://127.0.0.1:5500")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("cors");

app.MapControllers();

app.Run();
