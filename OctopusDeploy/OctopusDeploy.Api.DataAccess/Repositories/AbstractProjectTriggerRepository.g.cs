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
        public abstract class AbstractProjectTriggerRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProjectTriggerRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProjectTrigger>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
                }

                public async virtual Task<ProjectTrigger> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ProjectTrigger> Create(ProjectTrigger item)
                {
                        this.Context.Set<ProjectTrigger>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ProjectTrigger item)
                {
                        var entity = this.Context.Set<ProjectTrigger>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ProjectTrigger>().Attach(item);
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
                        ProjectTrigger record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ProjectTrigger>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<ProjectTrigger> GetProjectIdName(string projectId, string name)
                {
                        var records = await this.SearchLinqEF(x => x.ProjectId == projectId && x.Name == name);

                        return records.FirstOrDefault();
                }
                public async Task<List<ProjectTrigger>> GetProjectId(string projectId)
                {
                        var records = await this.SearchLinqEF(x => x.ProjectId == projectId);

                        return records;
                }

                protected async Task<List<ProjectTrigger>> Where(Expression<Func<ProjectTrigger, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ProjectTrigger> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ProjectTrigger>> SearchLinqEF(Expression<Func<ProjectTrigger, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProjectTrigger.Id)} ASC";
                        }

                        return await this.Context.Set<ProjectTrigger>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProjectTrigger>();
                }

                private async Task<List<ProjectTrigger>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ProjectTrigger.Id)} ASC";
                        }

                        return await this.Context.Set<ProjectTrigger>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProjectTrigger>();
                }

                private async Task<ProjectTrigger> GetById(string id)
                {
                        List<ProjectTrigger> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>9619309b7f1e4cb8b1869e1cd98f1479</Hash>
</Codenesium>*/