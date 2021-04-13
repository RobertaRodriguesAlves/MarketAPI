using Xunit;
using System;
using System.Linq;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Test.Product
{
    public class ProductCRUDTest
    {
        [Fact]
        public async Task WhenIsInsertedAValidProductList_ItShouldReturnItSelf()
        {
            ProductRepository productRepository = CreateInMemoryDataBase("Test1");
            List<ProductEntity> product = FillList();
            foreach (var item in product)
            {
                await productRepository.Insert(item);
            }

            IEnumerable<ProductEntity> productResult = await productRepository.SelectAsync();
            ProductEntity[] productList = productResult.ToArray();

            Assert.NotNull(productList);
            Assert.True(productList.Count().Equals(4));
        }

        [Fact]
        public async Task WhenIsAProductIsUpdated_ItShouldReturnItSelf()
        {
            ProductRepository productRepository = CreateInMemoryDataBase("Test2");
            List<ProductEntity> productList = FillList();
            
            foreach (var item in productList)
            {
                await productRepository.Insert(item);
            }
            var selectProd = await productRepository.SelectAsync();
            ProductEntity productModified = FillUpdateProduct(selectProd.ToArray());
            await productRepository.Update(productModified);
            var productUpdated = await productRepository.SelectByName(productModified.Name);

            Assert.Equal(productModified.Category, productUpdated.Category);
            Assert.Equal(productModified.Amount, productUpdated.Amount);
            Assert.Equal(productModified.CreatAt, productUpdated.CreatAt);
        }

        [Fact]
        public async Task WhenAProductFromAListIsDeleted_ItShouldNotBeReturned()
        {
            ProductRepository productRepository = CreateInMemoryDataBase("Test3");
            List<ProductEntity> productList = FillList();
            foreach (var item in productList)
            {
                await productRepository.Insert(item);
            }

            await productRepository.DeleteByName(productList[3].Name);
            var existingProducts = await productRepository.SelectAsync();

            Assert.NotNull(existingProducts);
            Assert.True(existingProducts.Count().Equals(3));
        }

        #region Methods
        private static ProductRepository CreateInMemoryDataBase(string dtBaseName)
        {
            var options = new DbContextOptionsBuilder<MarketDbContext>()
                                .UseInMemoryDatabase(dtBaseName)
                                .Options;
            var context = new MarketDbContext(options);
            var productRepository = new ProductRepository(context);
            return productRepository;
        }
        public static List<ProductEntity> FillList()
        {
            return new List<ProductEntity>
            {
                new ProductEntity{Name = Faker.Name.First(), Price = 23.45M, Promotion = false,
                        PromotionPrice = 0, Category = "Paper", Amount = 13,
                        CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow,
                        Provider = new ProviderEntity{Name = Faker.Name.FullName(), Cnpj = "13.445.814/0001-81"}},
                new ProductEntity{Name = Faker.Name.First(), Price = 2.45M, Promotion = true,
                        PromotionPrice = 1.85M, Category = "Paper", Amount = 4,
                        CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow,
                        Provider = new ProviderEntity{Name = Faker.Name.First(), Cnpj = "51.071.778/0001-22"}},
                new ProductEntity{Name = Faker.Name.First(), Price = 76.45M, Promotion = false,
                        PromotionPrice = 0, Category = "Construction", Amount = 24,
                        CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow,
                        Provider = new ProviderEntity{Name = Faker.Name.First(), Cnpj = "70.901.060/0001-60"}},
                new ProductEntity{Name = Faker.Name.First(), Price = 30.45M, Promotion = true,
                        PromotionPrice = 20.00M, Category = "Construction", Amount = 34,
                        CreatAt = DateTime.UtcNow, UpdateAt = DateTime.UtcNow,
                        Provider = new ProviderEntity{Name = Faker.Name.First(), Cnpj = "02.921.660/0001-30"}}
            };
        }
        private static ProductEntity FillUpdateProduct(ProductEntity[] resultList)
        {
            return new ProductEntity {Name = resultList[2].Name, 
                            Price = 0, Promotion = resultList[2].Promotion, 
                            PromotionPrice = resultList[2].PromotionPrice, Category = "Something", 
                            Amount = 2, 
                            Provider = resultList[2].Provider,
                            CreatAt = DateTime.UtcNow, UpdateAt = resultList[2].UpdateAt };
        }
        #endregion
    }
}