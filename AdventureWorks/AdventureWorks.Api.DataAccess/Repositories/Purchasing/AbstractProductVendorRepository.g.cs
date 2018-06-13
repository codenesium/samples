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
        public abstract class AbstractProductVendorRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductVendorRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductVendor>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProductVendor> Get(int productID)
                {
                        return await this.GetById(productID);
                }

                public async virtual Task<ProductVendor> Create(ProductVendor item)
                {
                        this.Context.Set<ProductVendor>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductVendor item)
                {
                        var entity = this.Context.Set<ProductVendor>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductVendor>().Attach(item);
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
                        ProductVendor record = await this.GetById(productID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductVendor>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<ProductVendor>> GetBusinessEntityID(int businessEntityID)
                {
                        var records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

                        return records;
                }
                public async Task<List<ProductVendor>> GetUnitMeasureCode(string unitMeasureCode)
                {
                        var records = await this.SearchLinqEF(x => x.UnitMeasureCode == unitMeasureCode);

                        return records;
                }

                protected async Task<List<ProductVendor>> Where(Expression<Func<ProductVendor, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProductVendor> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProductVendor>> SearchLinqEF(Expression<Func<ProductVendor, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
                        }

                        return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductVendor>();
                }

                private async Task<List<ProductVendor>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
                        }

                        return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductVendor>();
                }

                private async Task<ProductVendor> GetById(int productID)
                {
                        List<ProductVendor> records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>0de7b282f1b0b4c45a8bad9fc6a69e0b</Hash>
</Codenesium>*/