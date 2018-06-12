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
        public abstract class AbstractDashboardConfigurationRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractDashboardConfigurationRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<DashboardConfiguration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<DashboardConfiguration> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<DashboardConfiguration> Create(DashboardConfiguration item)
                {
                        this.Context.Set<DashboardConfiguration>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(DashboardConfiguration item)
                {
                        var entity = this.Context.Set<DashboardConfiguration>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<DashboardConfiguration>().Attach(item);
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
                        DashboardConfiguration record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<DashboardConfiguration>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                protected async Task<List<DashboardConfiguration>> Where(Expression<Func<DashboardConfiguration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<DashboardConfiguration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<DashboardConfiguration>> SearchLinqEF(Expression<Func<DashboardConfiguration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DashboardConfiguration.Id)} ASC";
                        }

                        return await this.Context.Set<DashboardConfiguration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DashboardConfiguration>();
                }

                private async Task<List<DashboardConfiguration>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(DashboardConfiguration.Id)} ASC";
                        }

                        return await this.Context.Set<DashboardConfiguration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DashboardConfiguration>();
                }

                private async Task<DashboardConfiguration> GetById(string id)
                {
                        List<DashboardConfiguration> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>5c881d84e3a4cc0721827019ea97fc9a</Hash>
</Codenesium>*/