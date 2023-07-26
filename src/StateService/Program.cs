using System.Reflection;
using StateComponents.Common.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var assemblyPartLoader = builder.Services.AddControllers();

foreach(var assemblyFile in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "StateComponents.*.dll"))
{
  Console.WriteLine("LOADING: " + assemblyFile);
  var assembly = Assembly.LoadFile(assemblyFile); 
  //assemblyPartLoader.AddApplicationPart(assembly);
}


builder.Services.AddControllers();

//builder.Services.AddControllers().AddApplicationPart(typeof(CommonController).Assembly);

Console.WriteLine("=============================================");

foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
{
  Console.WriteLine("LOADED: " + assembly.FullName);
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
  return "Hello from the State Service!";
})
.WithName("StateService")
.WithOpenApi();

app.MapControllers();

app.Run();