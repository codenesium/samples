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
        public abstract class AbstractProductModelIllustrationRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductModelIllustrationRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProductModelIllustration> Get(int productModelID)
                {
                        return await this.GetById(productModelID);
                }

                public async virtual Task<ProductModelIllustration> Create(ProductModelIllustration item)
                {
                        this.Context.Set<ProductModelIllustration>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductModelIllustration item)
                {
                        var entity = this.Context.Set<ProductModelIllustration>().Local.FirstOrDefault(x => x.ProductModelID == item.ProductModelID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductModelIllustration>().Attach(item);
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
                        ProductModelIllustration record = await this.GetById(productModelID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductModelIllustration>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ProductModelIllustration>> Where(Expression<Func<ProductModelIllustration, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProductModelIllustration> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProductModelIllustration>> SearchLinqEF(Expression<Func<ProductModelIllustration, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
                        }

                        return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductModelIllustration>();
                }

                private async Task<List<ProductModelIllustration>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
                        }

                        return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductModelIllustration>();
                }

                private async Task<ProductModelIllustration> GetById(int productModelID)
                {
                        List<ProductModelIllustration> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>14553dc3ac22d67a26c11c2f795d627b</Hash>
</Codenesium>*/