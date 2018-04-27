using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Jarcet.Qoutes.WebApi.DataObjects;
using Jarcet.Qoutes.WebApi.Models;
using Owin;

namespace Jarcet.Qoutes.WebApi
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            app.CreatePerOwinContext(QouteMobileContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            config.Services.Add(typeof(IExceptionLogger),
                new TraceSourceExceptionLogger(new
                    TraceSource("MyTraceSource", SourceLevels.All)));
            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;

            config.MapHttpAttributeRoutes();
            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();
                        settings.SkipVersionCheck = true;

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = EnvironmentVariables.SigningKey,
                    ValidAudiences = new[] { EnvironmentVariables.Website,"http://192.168.254.102:53197/" },
                    ValidIssuers = new[] { EnvironmentVariables.Website, "http://192.168.254.102:53197/" },
                    TokenHandler = config.GetAppServiceTokenHandler()
                    
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            List<TodoItem> todoItems = new List<TodoItem>
            {
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Complete = false },
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Complete = false }
            };

            foreach (TodoItem todoItem in todoItems)
            {
                context.Set<TodoItem>().Add(todoItem);
            }

            base.Seed(context);
        }
    }
    public class TraceSourceExceptionLogger : ExceptionLogger
    {
        private readonly TraceSource _traceSource;

        public TraceSourceExceptionLogger(TraceSource traceSource)
        {
            _traceSource = traceSource;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            //in this method get the exception details and add it to the sql databse
            _traceSource.TraceEvent(TraceEventType.Error, 1,
                "Unhandled exception processing {0} for {1}: {2}",
                context.Request.Method,
                context.Request.RequestUri,
                context.Exception);
        }
    }

    public static class EnvironmentVariables
    {
#if DEBUG
        public const string Website = "http://192.168.254.102:53197/";
#else
        public const string Website = "http://medtek.ml/app-service/";
#endif
        public const string SigningKey = "E2EED04CCCED91FD8170172FD529DAB9E32D65CEF7A50F9FE8545921135A77B4";
        
    }
}

