using System.Text.Json.Serialization;
using System.Text.Json;
using TriageConfigurationWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(j =>
{
    var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    options.Converters.Add(new JsonStringEnumConverter());
    var converter = new TriageConfigConverter(options);

    j.JsonSerializerOptions.Converters.Add(converter);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
