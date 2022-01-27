﻿using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ShoppingAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingClient.Data
{
    public class ProductContext
    {
        
        public IMongoCollection<Product> Products { get; }
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        private  static void SeedData(IMongoCollection<Product> productCollection)
        {
            var existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());

            }
        }

        public static List<Product> GetPreconfiguredProducts()

        {
            return new List<Product>(){
                      
                        new Product()
                        {
                            Name = "India-IPhone X",
                            Description = "This Inida's phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-A1.png",
                            Price = 50.00M,
                            Category = "India Smart Phone"
                        },
                        new Product()
                        {
                            Name = "IPhone X",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-1.png",
                            Price = 950.00M,
                            Category = "Smart Phone"
                        },
                        new Product()
                        {
                            Name = "Samsung 10",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-2.png",
                            Price = 840.00M,
                            Category = "Smart Phone"
                        },
                        new Product()
                        {
                            Name = "Huawei Plus",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-3.png",
                            Price = 650.00M,
                            Category = "White Appliances"
                        },
                        new Product()
                        {
                            Name = "Xiaomi Mi 9",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-4.png",
                            Price = 470.00M,
                            Category = "White Appliances"
                        },
                        new Product()
                        {
                            Name = "HTC U11+ Plus",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-5.png",
                            Price = 380.00M,
                            Category = "Smart Phone"
                        },
                        new Product()
                        {
                            Name = "LG G7 ThinQ EndofCourse",
                            Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                            ImageFile = "product-6.png",
                            Price = 240.00M,
                            Category = "Home Kitchen"
                        }
                };
        }
    }
}
