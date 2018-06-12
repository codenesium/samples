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
        public abstract class AbstractActionTemplateRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractActionTemplateRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ActionTemplate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<ActionTemplate> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ActionTemplate> Create(ActionTemplate item)
                {
                        this.Context.Set<ActionTemplate>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ActionTemplate item)
                {
                        var entity = this.Context.Set<ActionTemplate>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ActionTemplate>().Attach(item);
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
                        ActionTemplate record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ActionTemplate>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ActionTemplate> GetName(string name)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name);

                        return records.FirstOrDefault();
                }

                protected async Task<List<ActionTemplate>> Where(Expression<Func<ActionTemplate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ActionTemplate> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ActionTemplate>> SearchLinqEF(Expression<Func<ActionTemplate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ActionTemplate.Id)} ASC";
                        }

                        return await this.Context.Set<ActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ActionTemplate>();
                }

                private async Task<List<ActionTemplate>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ActionTemplate.Id)} ASC";
                        }

                        return await this.Context.Set<ActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ActionTemplate>();
                }

                private async Task<ActionTemplate> GetById(string id)
                {
                        List<ActionTemplate> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a156d1633ae39ba4d0a58a3b8a16efc8</Hash>
</Codenesium>*/