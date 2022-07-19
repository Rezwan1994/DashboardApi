using Autofac;
using Autofac.Extensions.DependencyInjection;
using DashboardAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.Text;

try
{
	var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
    containerBuilder
.RegisterModule(new ApiModule());
});
	// Add services to the container.

	builder.Services.AddAuthentication()
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
	{
		x.RequireHttpsMetadata = false;
		x.SaveToken = true;
		x.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidIssuer = builder.Configuration["Jwt:Issuer"],
			ValidAudience = builder.Configuration["Jwt:Audience"]
		};
	});

	builder.Services.AddAuthorization(options =>
	{
		options.AddPolicy("AccessPermission", policy =>
		{
			policy.AuthenticationSchemes.Clear();
			policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
			policy.RequireAuthenticatedUser();
	
		});
	});
	builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Host.UseSerilog((ctx, lc) => lc
	.MinimumLevel.Debug()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
	.Enrich.FromLogContext()
	.ReadFrom.Configuration(builder.Configuration));

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}

	app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();  
}
catch(Exception ex)
{
	Log.Fatal(ex, "Application start-up failed");
}

