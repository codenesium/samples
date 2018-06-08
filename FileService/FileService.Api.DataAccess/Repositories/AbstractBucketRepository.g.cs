using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public abstract class AbstractBucketRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractBucketRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Bucket>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<Bucket> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Bucket> Create(Bucket item)
                {
                        this.Context.Set<Bucket>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Bucket item)
                {
                        var entity = this.Context.Set<Bucket>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Bucket>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        int id)
                {
                        Bucket record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Bucket>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Bucket> GetExternalId(Guid externalId)
                {
                        var records = await this.SearchLinqEF(x => x.ExternalId == externalId);

                        return records.FirstOrDefault();
                }
                public async Task<Bucket> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Bucket>> Where(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<Bucket> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<Bucket>> SearchLinqEF(Expression<Func<Bucket, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Bucket.Id)} ASC";
                        }

                        return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Bucket>();
                }

                private async Task<List<Bucket>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(Bucket.Id)} ASC";
                        }

                        return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Bucket>();
                }

                private async Task<Bucket> GetById(int id)
                {
                        List<Bucket> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>52a0ff1613993b534afa3c4e67421973</Hash>
</Codenesium>*/