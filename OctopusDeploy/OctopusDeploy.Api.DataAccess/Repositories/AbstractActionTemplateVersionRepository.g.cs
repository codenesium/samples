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
        public abstract class AbstractActionTemplateVersionRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractActionTemplateVersionRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ActionTemplateVersion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<ActionTemplateVersion> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ActionTemplateVersion> Create(ActionTemplateVersion item)
                {
                        this.Context.Set<ActionTemplateVersion>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ActionTemplateVersion item)
                {
                        var entity = this.Context.Set<ActionTemplateVersion>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ActionTemplateVersion>().Attach(item);
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
                        ActionTemplateVersion record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ActionTemplateVersion>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ActionTemplateVersion> GetNameVersion(string name, int version)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name && x.Version == version);

                        return records.FirstOrDefault();
                }
                public async Task<List<ActionTemplateVersion>> GetLatestActionTemplateId(string latestActionTemplateId)
                {
                        var records = await this.SearchLinqEF(x => x.LatestActionTemplateId == latestActionTemplateId);

                        return records;
                }

                protected async Task<List<ActionTemplateVersion>> Where(Expression<Func<ActionTemplateVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ActionTemplateVersion> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ActionTemplateVersion>> SearchLinqEF(Expression<Func<ActionTemplateVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ActionTemplateVersion.Id)} ASC";
                        }

                        return await this.Context.Set<ActionTemplateVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ActionTemplateVersion>();
                }

                private async Task<List<ActionTemplateVersion>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ActionTemplateVersion.Id)} ASC";
                        }

                        return await this.Context.Set<ActionTemplateVersion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ActionTemplateVersion>();
                }

                private async Task<ActionTemplateVersion> GetById(string id)
                {
                        List<ActionTemplateVersion> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>f2b11da08365119ab91c6c8a8c531e4d</Hash>
</Codenesium>*/