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
        public abstract class AbstractProductModelProductDescriptionCultureRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductModelProductDescriptionCultureRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductModelProductDescriptionCulture>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProductModelProductDescriptionCulture> Get(int productModelID)
                {
                        return await this.GetById(productModelID);
                }

                public async virtual Task<ProductModelProductDescriptionCulture> Create(ProductModelProductDescriptionCulture item)
                {
                        this.Context.Set<ProductModelProductDescriptionCulture>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductModelProductDescriptionCulture item)
                {
                        var entity = this.Context.Set<ProductModelProductDescriptionCulture>().Local.FirstOrDefault(x => x.ProductModelID == item.ProductModelID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductModelProductDescriptionCulture>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int productModelID)
                {
                        ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductModelProductDescriptionCulture>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ProductModelProductDescriptionCulture>> Where(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProductModelProductDescriptionCulture> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProductModelProductDescriptionCulture>> SearchLinqEF(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
                        }

                        return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
                }

                private async Task<List<ProductModelProductDescriptionCulture>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
                        }

                        return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
                }

                private async Task<ProductModelProductDescriptionCulture> GetById(int productModelID)
                {
                        List<ProductModelProductDescriptionCulture> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>fdd708f77a45d357fb63cd5e597c4c16</Hash>
</Codenesium>*/