﻿using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyJetWallet.Sdk.GrpcSchema;
using MyJetWallet.Sdk.Postgres;
using MyJetWallet.Sdk.Service;
using Prometheus;
using Service.AssetsDictionary.Grpc;
using Service.AssetsDictionary.Modules;
using Service.AssetsDictionary.Postgres;
using Service.AssetsDictionary.Services;
using Service.Core.Client.Constants;
using Service.Grpc;
using SimpleTrading.ServiceStatusReporterConnector;

namespace Service.AssetsDictionary
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.BindGrpc();
            services.AddHostedService<ApplicationLifetimeManager>();
            services.AddMyTelemetry(Configuration.TelemetryPrefix, Program.Settings.ZipkinUrl);
            services.AddDatabase(DatabaseContext.Schema, Program.Settings.PostgresConnectionString, options => new DatabaseContext(options));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseMetricServer();
            app.BindServicesTree(Assembly.GetExecutingAssembly());
            app.BindIsAlive();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcSchema<AssetsDictionaryService, IAssetsDictionaryService>();
                endpoints.MapGrpcSchemaRegistry();
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"); });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<SettingsModule>();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
