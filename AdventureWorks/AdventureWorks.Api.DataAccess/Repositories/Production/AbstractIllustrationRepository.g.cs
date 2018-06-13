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
        public abstract class AbstractIllustrationRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractIllustrationRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Illustration>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<Illustration> Get(int illustrationID)
                {
                        return await this.GetById(illustrationID);
                }

                public async virtual Task<Illustration> Create(Illustration item)
                {
                        this.Context.Set<Illustration>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Illustration item)
                {
                        var entity = this.Context.Set<Illustration>().Local.FirstOrDefault(x => x.IllustrationID == item.IllustrationID);
                        if (entity == null)
                        {
                                this.Context.Set<Illustration>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int illustrationID)
                {
                        Illustration record = await this.GetById(illustrationID);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Illustration>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<Illustration>> Where(Expression<Func<Illustration, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<Illustration> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<Illustration>> SearchLinqEF(Expression<Func<Illustration, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Illustration.IllustrationID)} ASC";
                        }

                        return await this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Illustration>();
                }

                private async Task<List<Illustration>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Illustration.IllustrationID)} ASC";
                        }

                        return await this.Context.Set<Illustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<Illustration>();
                }

                private async Task<Illustration> GetById(int illustrationID)
                {
                        List<Illustration> records = await this.SearchLinqEF(x => x.IllustrationID == illustrationID);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<ProductModelIllustration>> ProductModelIllustrations(int illustrationID, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<ProductModelIllustration>().Where(x => x.IllustrationID == illustrationID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductModelIllustration>();
                }
        }
}

/*<Codenesium>
    <Hash>eae31a6faa447b0ec0faf96a1f655a68</Hash>
</Codenesium>*/