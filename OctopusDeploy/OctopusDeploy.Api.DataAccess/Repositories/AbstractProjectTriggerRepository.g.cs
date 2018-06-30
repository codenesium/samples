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

namespace OctopusDeployNS.Api.DataAccess
{
        public abstract class AbstractProjectTriggerRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractProjectTriggerRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ProjectTrigger>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
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

                public async Task<ProjectTrigger> ByProjectIdName(string projectId, string name)
                {
                        var records = await this.Where(x => x.ProjectId == projectId && x.Name == name);

                        return records.FirstOrDefault();
                }

                public async Task<List<ProjectTrigger>> ByProjectId(string projectId)
                {
                        var records = await this.Where(x => x.ProjectId == projectId);

                        return records;
                }

                protected async Task<List<ProjectTrigger>> Where(
                        Expression<Func<ProjectTrigger, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ProjectTrigger, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ProjectTrigger>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProjectTrigger>();
                        }
                        else
                        {
                                return await this.Context.Set<ProjectTrigger>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProjectTrigger>();
                        }
                }

                private async Task<ProjectTrigger> GetById(string id)
                {
                        List<ProjectTrigger> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>a203ab00e5d238aac2a3f18bd8c5ec41</Hash>
</Codenesium>*/