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
        public abstract class AbstractProductProductPhotoRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductProductPhotoRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProductProductPhoto> Get(int productID)
                {
                        return await this.GetById(productID);
                }

                public async virtual Task<ProductProductPhoto> Create(ProductProductPhoto item)
                {
                        this.Context.Set<ProductProductPhoto>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductProductPhoto item)
                {
                        var entity = this.Context.Set<ProductProductPhoto>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductProductPhoto>().Attach(item);
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
                        ProductProductPhoto record = await this.GetById(productID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductProductPhoto>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ProductProductPhoto>> Where(Expression<Func<ProductProductPhoto, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProductProductPhoto> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProductProductPhoto>> SearchLinqEF(Expression<Func<ProductProductPhoto, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductProductPhoto.ProductID)} ASC";
                        }

                        return await this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
                }

                private async Task<List<ProductProductPhoto>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductProductPhoto.ProductID)} ASC";
                        }

                        return await this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
                }

                private async Task<ProductProductPhoto> GetById(int productID)
                {
                        List<ProductProductPhoto> records = await this.SearchLinqEF(x => x.ProductID == productID);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>151c25d36dfb65c2ff5105f915b71efc</Hash>
</Codenesium>*/