using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Settings
{
    public class ConfigurationHelper
    {

            public readonly string connectionString = string.Empty;

            public ConfigurationHelper()
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                connectionString = root.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            }

            public string DefaultConnectionString { get => connectionString; }
    }
}
