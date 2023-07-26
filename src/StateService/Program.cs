using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

foreach(var assemblyFile in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "StateComponents.*.dll"))
{
  Console.WriteLine("LOADING: " + assemblyFile);
  Assembly.LoadFile(assemblyFile);  
}

builder.Services.AddControllers();

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