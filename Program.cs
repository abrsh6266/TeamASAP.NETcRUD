using NewWeb.Services;
using NewWeb.Settings;
var builder = WebApplication.CreateBuilder(args);
// MongoDB settings
builder.Services.Configure<DatabaseSetting>(builder.Configuration.GetSection("MongoDB"));
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<TeamService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
