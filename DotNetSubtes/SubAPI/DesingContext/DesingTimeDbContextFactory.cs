using Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SubAPI.DesingContext
{
    public class DesingTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
            public ApplicationContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var builder = new DbContextOptionsBuilder<ApplicationContext>();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                builder.UseSqlServer(connectionString);

                return new ApplicationContext(builder.Options);
            }
    }
}
