using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public abstract class AbstractProductVendorRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductVendorRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductVendor>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<List<ProductVendor>> ByBusinessEntityID(int businessEntityID)
                {
                        var records = await this.Where(x => x.BusinessEntityID == businessEntityID);

                        return records;
                }

                public async Task<List<ProductVendor>> ByUnitMeasureCode(string unitMeasureCode)
                {
                        var records = await this.Where(x => x.UnitMeasureCode == unitMeasureCode);

                        return records;
                }

                protected async Task<List<ProductVendor>> Where(
                        Expression<Func<ProductVendor, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ProductVendor, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.ProductID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductVendor>();
                        }
                        else
                        {
                                return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductVendor>();
                        }
                }

                private async Task<ProductVendor> GetById(int productID)
                {
                        List<ProductVendor> records = await this.Where(x => x.ProductID == productID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a2710e6810e5574bacadec3c79433cb8</Hash>
</Codenesium>*/