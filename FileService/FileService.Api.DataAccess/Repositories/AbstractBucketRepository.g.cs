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

                public virtual Task<List<Bucket>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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
                        var records = await this.Where(x => x.ExternalId == externalId);

                        return records.FirstOrDefault();
                }
                public async Task<Bucket> GetName(string name)
                {
                        var records = await this.Where(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<Bucket>> Where(
                        Expression<Func<Bucket, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Bucket, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Bucket>();
                        }
                        else
                        {
                                return await this.Context.Set<Bucket>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Bucket>();
                        }
                }

                private async Task<Bucket> GetById(int id)
                {
                        List<Bucket> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }

                public async virtual Task<List<File>> Files(int bucketId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<File>().Where(x => x.BucketId == bucketId).AsQueryable().Skip(offset).Take(limit).ToListAsync<File>();
                }
        }
}

/*<Codenesium>
    <Hash>6a73f609a19999e72a835c3f83dc4679</Hash>
</Codenesium>*/