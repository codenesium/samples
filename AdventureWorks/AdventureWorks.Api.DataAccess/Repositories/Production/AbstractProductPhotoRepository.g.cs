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
        public abstract class AbstractProductPhotoRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProductPhotoRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProductPhoto>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<ProductPhoto> Get(int productPhotoID)
                {
                        return await this.GetById(productPhotoID);
                }

                public async virtual Task<ProductPhoto> Create(ProductPhoto item)
                {
                        this.Context.Set<ProductPhoto>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProductPhoto item)
                {
                        var entity = this.Context.Set<ProductPhoto>().Local.FirstOrDefault(x => x.ProductPhotoID == item.ProductPhotoID);
                        if (entity == null)
                        {
                                this.Context.Set<ProductPhoto>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int productPhotoID)
                {
                        ProductPhoto record = await this.GetById(productPhotoID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProductPhoto>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<ProductPhoto>> Where(Expression<Func<ProductPhoto, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ProductPhoto> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ProductPhoto>> SearchLinqEF(Expression<Func<ProductPhoto, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductPhoto.ProductPhotoID)} ASC";
                        }

                        return await this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductPhoto>();
                }

                private async Task<List<ProductPhoto>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProductPhoto.ProductPhotoID)} ASC";
                        }

                        return await this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ProductPhoto>();
                }

                private async Task<ProductPhoto> GetById(int productPhotoID)
                {
                        List<ProductPhoto> records = await this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<ProductProductPhoto>> ProductProductPhotoes(int productPhotoID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductProductPhoto>().Where(x => x.ProductPhotoID == productPhotoID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
                }
        }
}

/*<Codenesium>
    <Hash>d010b72cad23ce154bad9b9669c22c9d</Hash>
</Codenesium>*/