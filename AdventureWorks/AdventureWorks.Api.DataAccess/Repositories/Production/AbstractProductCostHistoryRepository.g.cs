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
        public abstract class AbstractProductCostHistoryRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductCostHistoryRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProductCostHistory> Get(int productID)
                {
                        return await this.GetById(productID);
                }

                public async virtual Task<ProductCostHistory> Create(ProductCostHistory item)
                {
                        this.Context.Set<ProductCostHistory>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductCostHistory item)
                {
                        var entity = this.Context.Set<ProductCostHistory>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductCostHistory>().Attach(item);
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
                        ProductCostHistory record = await this.GetById(productID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductCostHistory>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ProductCostHistory>> Where(Expression<Func<ProductCostHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProductCostHistory> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProductCostHistory>> SearchLinqEF(Expression<Func<ProductCostHistory, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductCostHistory.ProductID)} ASC";
                        }

                        return await this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductCostHistory>();
                }

                private async Task<List<ProductCostHistory>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductCostHistory.ProductID)} ASC";
                        }

                        return await this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductCostHistory>();
                }

                private async Task<ProductCostHistory> GetById(int productID)
                {
                        List<ProductCostHistory> records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>0e1005984d0ad71952c7261811432047</Hash>
</Codenesium>*/