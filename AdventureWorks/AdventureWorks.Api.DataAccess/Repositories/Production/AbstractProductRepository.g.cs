using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractProductRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Product>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Product> Get(int productID)
                {
                        return await this.GetById(productID);
                }

                public async virtual Task<Product> Create(Product item)
                {
                        this.Context.Set<Product>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Product item)
                {
                        var entity = this.Context.Set<Product>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
                        if (entity == null)
                        {
                                this.Context.Set<Product>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int productID)
                {
                        Product record = await this.GetById(productID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Product>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Product> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<Product> GetProductNumber(string productNumber)
                {
                        var records = await this.SearchLinqEF(x => x.ProductNumber == productNumber);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Product>> Where(Expression<Func<Product, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Product> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Product>> SearchLinqEF(Expression<Func<Product, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Product.ProductID)} ASC";
                        }

                        return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Product>();
                }

                private async Task<List<Product>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Product.ProductID)} ASC";
                        }

                        return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Product>();
                }

                private async Task<Product> GetById(int productID)
                {
                        List<Product> records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<BillOfMaterials>> BillOfMaterials(int componentID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<BillOfMaterials>().Where(x => x.ComponentID == componentID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterials>();
                }
                public async virtual Task<List<ProductCostHistory>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductCostHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductCostHistory>();
                }
                public async virtual Task<List<ProductDocument>> ProductDocuments(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductDocument>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductDocument>();
                }
                public async virtual Task<List<ProductInventory>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductInventory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductInventory>();
                }
                public async virtual Task<List<ProductListPriceHistory>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductListPriceHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductListPriceHistory>();
                }
                public async virtual Task<List<ProductProductPhoto>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductProductPhoto>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
                }
                public async virtual Task<List<ProductReview>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductReview>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductReview>();
                }
                public async virtual Task<List<TransactionHistory>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<TransactionHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
                }
                public async virtual Task<List<WorkOrder>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<WorkOrder>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrder>();
                }
        }
}

/*<Codenesium>
    <Hash>9f3503f7b582858c1dc59dcdd19b2205</Hash>
</Codenesium>*/