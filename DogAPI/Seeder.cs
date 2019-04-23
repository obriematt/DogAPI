using DogAPI.Contexts;
using DogAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DogAPI
{
    public static class Seeder
    {
        public static void Seedit(string jsonData,
                                  IServiceProvider serviceProvider)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateSetterContractResolver()
            };
            List<Dog> dogs = JsonConvert.DeserializeObject<List<Dog>>(jsonData, settings);
            using ( var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DogContext>();
                if (!context.Dogs.Any())
                {
                    foreach(Dog newDog in dogs)
                    {
                        context.Add(newDog);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
