using Microsoft.AspNetCore.HttpOverrides;
using Shmshad.Presentation.Extensions;
using NLog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Formatters;
using Contracts;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
    "/nlog.config"));

// Add Extention to the builder
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage(); 
else 
    app.UseHsts();

//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// Configure the HTTP request pipeline.
var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);
if (app.Environment.IsProduction())
    app.UseHsts();
//app.UseHttpsRedirection();

app.UseStaticFiles(); 
/*app.UseForwardedHeaders(new ForwardedHeadersOptions
{ 
    ForwardedHeaders = ForwardedHeaders.All
}); 
app.UseCors("CorsPolicy");

app.UseAuthentication();*/

app.UseAuthorization();

app.MapControllers();

app.Run();

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
    new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
    .Services.BuildServiceProvider()
    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
    .OfType<NewtonsoftJsonPatchInputFormatter>().First();