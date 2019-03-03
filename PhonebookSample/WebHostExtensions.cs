using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PhonebookSample.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhonebookSample
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<PhonebookContext>();
                new PhonebookDataSeeder(context).SeedData();
            }
            return host;
        }
    }
}
