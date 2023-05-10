using System.Net;
using AspNetCore.ResponseWrapper;
using Identity.Application;
using Infrastructure.DbContexts;
using Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddIdentityPart();
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});
builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.SlidingExpiration = true;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoInjectServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(applicationBuilder =>
{
    applicationBuilder.Run(async context =>
    {
        var errorFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (errorFeature?.Error is BusinessException businessException)
        {
            await context.Response.WriteAsJsonAsync(new
            {
                code = businessException.Code,
                message = businessException.Message
            });
            return;
        }

        await context.Response.WriteAsJsonAsync(new
        {
            code = HttpStatusCode.InternalServerError,
            message = "服务器内部错误"
        });
    });
});

app.MapControllers();

app.Run();