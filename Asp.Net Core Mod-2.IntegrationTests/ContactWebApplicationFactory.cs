﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asp.Net_Core_Mod_2.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Asp.Net_Core_Mod_2.IntegrationTests
{
    public class ContactWebApplicationFactory  : WebApplicationFactory<Program> 
    {
        public IConfiguration Configuration { get; private set; }
        /*
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("integrationsettings.json")
                    .Build();

                config.AddConfiguration(Configuration);
                
            });

            builder.ConfigureTestServices(services =>
            {
              //services.AddTransient<ContactsController, ContactsControllerMock>();
            });
        }
        */
    }
  
}
