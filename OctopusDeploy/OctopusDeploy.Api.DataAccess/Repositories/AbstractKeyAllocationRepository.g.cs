using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractKeyAllocationRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractKeyAllocationRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<KeyAllocation>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<KeyAllocation> Get(string collectionName)
                {
                        return await this.GetById(collectionName);
                }

                public async virtual Task<KeyAllocation> Create(KeyAllocation item)
                {
                        this.Context.Set<KeyAllocation>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(KeyAllocation item)
                {
                        var entity = this.Context.Set<KeyAllocation>().Local.FirstOrDefault(x => x.CollectionName == item.CollectionName);
                        if (entity == null)
                        {
                                this.Context.Set<KeyAllocation>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string collectionName)
                {
                        KeyAllocation record = await this.GetById(collectionName);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<KeyAllocation>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<KeyAllocation>> Where(Expression<Func<KeyAllocation, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<KeyAllocation> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<KeyAllocation>> SearchLinqEF(Expression<Func<KeyAllocation, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(KeyAllocation.CollectionName)} ASC";
                        }

                        return await this.Context.Set<KeyAllocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<KeyAllocation>();
                }

                private async Task<List<KeyAllocation>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(KeyAllocation.CollectionName)} ASC";
                        }

                        return await this.Context.Set<KeyAllocation>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<KeyAllocation>();
                }

                private async Task<KeyAllocation> GetById(string collectionName)
                {
                        List<KeyAllocation> records = await this.SearchLinqEF(x => x.CollectionName == collectionName);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>ad022bf96065f1fae74e5282c8076486</Hash>
</Codenesium>*/