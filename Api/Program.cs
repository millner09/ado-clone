using Api.Extensions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
ConfigureServices(builder);

var app = builder.Build();
ConfigureApp(app);
app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var services = builder.Services;
    services.AddControllers(opt =>
    {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        opt.Filters.Add(new AuthorizeFilter(policy));
    });
    //.AddFluentValidation(config =>
    //{
    //    config.RegisterValidatorsFromAssemblyContaining<ActivityValidator>();
    //});    
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddHttpContextAccessor();
    services.AddApplicationServices(builder.Configuration);
    services.AddIdentityServices(builder.Configuration);
}

void ConfigureApp(WebApplication app)
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseHttpsRedirection();
    app.UseCors("CorsPolicy");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
}