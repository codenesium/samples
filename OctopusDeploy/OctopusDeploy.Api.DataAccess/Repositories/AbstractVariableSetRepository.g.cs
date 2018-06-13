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
        public abstract class AbstractVariableSetRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractVariableSetRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<VariableSet>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
                }

                public async virtual Task<VariableSet> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<VariableSet> Create(VariableSet item)
                {
                        this.Context.Set<VariableSet>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(VariableSet item)
                {
                        var entity = this.Context.Set<VariableSet>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<VariableSet>().Attach(item);
                        }
                        else
                        {
                                this.Context.Entry(entity).CurrentValues.SetValues(item);
                        }

                        await this.Context.SaveChangesAsync();
                }

                public async virtual Task Delete(
                        string id)
                {
                        VariableSet record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<VariableSet>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<VariableSet>> Where(Expression<Func<VariableSet, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<VariableSet> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<VariableSet>> SearchLinqEF(Expression<Func<VariableSet, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(VariableSet.Id)} ASC";
                        }

                        return await this.Context.Set<VariableSet>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<VariableSet>();
                }

                private async Task<List<VariableSet>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(VariableSet.Id)} ASC";
                        }

                        return await this.Context.Set<VariableSet>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<VariableSet>();
                }

                private async Task<VariableSet> GetById(string id)
                {
                        List<VariableSet> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>5f9186a4afa8f2eb0181e5da8b1b59b3</Hash>
</Codenesium>*/