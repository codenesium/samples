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

                public virtual Task<List<ActionTemplate>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, limit, offset, orderClause);
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

                protected async Task<List<ActionTemplate>> Where(Expression<Func<ActionTemplate, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        List<ActionTemplate> records = await this.SearchLinqEF(predicate, limit, offset, orderClause);

                        return records;
                }

                private async Task<List<ActionTemplate>> SearchLinqEF(Expression<Func<ActionTemplate, bool>> predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ActionTemplate.Id)} ASC";
                        }

                        return await this.Context.Set<ActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ActionTemplate>();
                }

                private async Task<List<ActionTemplate>> SearchLinqEFDynamic(string predicate, int limit = int.MaxValue, int offset = 0, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ActionTemplate.Id)} ASC";
                        }

                        return await this.Context.Set<ActionTemplate>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(offset).Take(limit).ToListAsync<ActionTemplate>();
                }

                private async Task<ActionTemplate> GetById(string id)
                {
                        List<ActionTemplate> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>46d9518e2869701e540c3908c8148c78</Hash>
</Codenesium>*/