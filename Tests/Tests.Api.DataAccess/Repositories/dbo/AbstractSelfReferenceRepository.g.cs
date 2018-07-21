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

namespace TestsNS.Api.DataAccess
{
        public abstract class AbstractSelfReferenceRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractSelfReferenceRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<SelfReference>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<SelfReference> Get(int id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<SelfReference> Create(SelfReference item)
                {
                        this.Context.Set<SelfReference>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(SelfReference item)
                {
                        var entity = this.Context.Set<SelfReference>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<SelfReference>().Attach(item);
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
                        SelfReference record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<SelfReference>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async virtual Task<List<SelfReference>> SelfReferences(int selfReferenceId, int limit = int.MaxValue, int offset = 0)
                {
                        return await this.Context.Set<SelfReference>().Where(x => x.SelfReferenceId == selfReferenceId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SelfReference>();
                }

                protected async Task<List<SelfReference>> Where(
                        Expression<Func<SelfReference, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<SelfReference, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<SelfReference>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<SelfReference>();
                        }
                        else
                        {
                                return await this.Context.Set<SelfReference>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<SelfReference>();
                        }
                }

                private async Task<SelfReference> GetById(int id)
                {
                        List<SelfReference> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>261ddbe5753a43ac9e964f680e0854ba</Hash>
</Codenesium>*/