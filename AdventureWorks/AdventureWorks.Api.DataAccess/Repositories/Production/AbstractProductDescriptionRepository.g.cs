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
        public abstract class AbstractProductDescriptionRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductDescriptionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductDescription>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<ProductDescription> Get(int productDescriptionID)
                {
                        return await this.GetById(productDescriptionID);
                }

                public async virtual Task<ProductDescription> Create(ProductDescription item)
                {
                        this.Context.Set<ProductDescription>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductDescription item)
                {
                        var entity = this.Context.Set<ProductDescription>().Local.FirstOrDefault(x => x.ProductDescriptionID == item.ProductDescriptionID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductDescription>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int productDescriptionID)
                {
                        ProductDescription record = await this.GetById(productDescriptionID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductDescription>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(x => x.ProductDescriptionID == productDescriptionID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
                }

                protected async Task<List<ProductDescription>> Where(
                        Expression<Func<ProductDescription, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ProductDescription, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.ProductDescriptionID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductDescription>();
                        }
                        else
                        {
                                return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductDescription>();
                        }
                }

                private async Task<ProductDescription> GetById(int productDescriptionID)
                {
                        List<ProductDescription> records = await this.Where(x => x.ProductDescriptionID == productDescriptionID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>edc8c24f9af2f41cb6633fe16097699b</Hash>
</Codenesium>*/