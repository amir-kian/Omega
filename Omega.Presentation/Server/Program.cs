using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Omega.Core.DTOs;
using Omega.Domain.Commands;
using Omega.Domain.Commands.Request;
using Omega.Domain.Events;
using Omega.Domain.Events.Request;
using Omega.Domain.Interfaces;
using Omega.Domain.Interfaces.Request;
using Omega.Domain.Queries;
using Omega.ExternalService.EbeheshtServices;
using Omega.ExternalService.EbeheshtServices.Contracts;
using Omega.Presentation.Infrastructure;
using Omega.Repository;
using Omega.Repository.Request;
using Omega.Service.Handlers;
using Omega.Service.Handlers.Request;

namespace Omega.Presentation.Server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddRazorPages();

			// Configure the DbContext.
			builder.Services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
			});
			builder.Services.AddScoped<IRequestHandler<GetAllCustomersQuery, CustomerReadDTO[]>, GetAllCustomersQueryHandler>();

			builder.Services.AddScoped<IWriteCustomerRepository, WriteCustomerRepository>();
			builder.Services.AddScoped<IReadCustomerRepository, ReadCustomerRepository>();
			builder.Services.AddScoped<IEventRepository<IDomainEvent>, EventRepository>();
			builder.Services.AddScoped<ICustomerEventHandler, CustomerEventHandler>();
			
			builder.Services.AddScoped<IEbeheshtService, EbeheshtService>();

			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommand))
				.RegisterServicesFromAssemblyContaining(typeof(CreateCustomerCommandHandler)));

			builder.Services.AddScoped<IWriteRequestRepository, WriteRequestRepository>();
			builder.Services.AddScoped<IReadRequestRepository, ReadRequestRepository>();
			builder.Services.AddScoped<IEventRepository<IDomainEvent>, EventRepository>();
			builder.Services.AddScoped<IRequestEventHandler, RequestEventHandler>();

			builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateRequestCommand))
				.RegisterServicesFromAssemblyContaining(typeof(CreateRequestCommandHandler)));





			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name V1");
				c.RoutePrefix = string.Empty;
			});

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.MapRazorPages();
			app.MapControllers();
			app.MapFallbackToFile("index.html");

			app.Run();
		}
	}
}