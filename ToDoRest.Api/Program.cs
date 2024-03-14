using ToDoRest.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IToDoService, ToDoService>();

var app = builder.Build();
//Middleware execution priority. Order matters.
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

