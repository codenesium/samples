using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

                public virtual Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                protected async Task<List<ProductModelIllustration>> Where(
                        Expression<Func<ProductModelIllustration, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ProductModelIllustration, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.ProductModelID;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModelIllustration>();
                        }
                        else
                        {
                                return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModelIllustration>();
                        }
                }

                private async Task<ProductModelIllustration> GetById(int productModelID)
                {
                        List<ProductModelIllustration> records = await this.Where(x => x.ProductModelID == productModelID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>aa787734620b0a22bcfecc9a92b06e83</Hash>
</Codenesium>*/