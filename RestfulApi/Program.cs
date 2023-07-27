using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;
using RestfulApi.Business.Services.Abstract;
using RestfulApi.Business.Services.Concrete;
using RestfulApi.Business.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IMissionService, MissionService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( s => {
    s.SwaggerDoc("V1", new OpenApiInfo { Title = "Sipay Cohorts Week #2", Version = "V1" });
});
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(s =>
    {
        s.SwaggerEndpoint("/swagger/V1/swagger.json", "Sipay - Week #2 V1");
    });
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<LogMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
