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
        public abstract class AbstractReleaseRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractReleaseRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<Release>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<Release> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<Release> Create(Release item)
                {
                        this.Context.Set<Release>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(Release item)
                {
                        var entity = this.Context.Set<Release>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<Release>().Attach(item);
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
                        Release record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<Release>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<Release> ByVersionProjectId(string version, string projectId)
                {
                        var records = await this.Where(x => x.Version == version && x.ProjectId == projectId);

                        return records.FirstOrDefault();
                }

                public async Task<List<Release>> ByIdAssembled(string id, DateTimeOffset assembled)
                {
                        var records = await this.Where(x => x.Id == id && x.Assembled == assembled);

                        return records;
                }

                public async Task<List<Release>> ByProjectDeploymentProcessSnapshotId(string projectDeploymentProcessSnapshotId)
                {
                        var records = await this.Where(x => x.ProjectDeploymentProcessSnapshotId == projectDeploymentProcessSnapshotId);

                        return records;
                }

                public async Task<List<Release>> ByIdVersionProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdChannelIdAssembled(string id, string version, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string channelId, DateTimeOffset assembled)
                {
                        var records = await this.Where(x => x.Id == id && x.Version == version && x.ProjectVariableSetSnapshotId == projectVariableSetSnapshotId && x.ProjectDeploymentProcessSnapshotId == projectDeploymentProcessSnapshotId && x.JSON == jSON && x.ProjectId == projectId && x.ChannelId == channelId && x.Assembled == assembled);

                        return records;
                }

                public async Task<List<Release>> ByIdChannelIdProjectVariableSetSnapshotIdProjectDeploymentProcessSnapshotIdJSONProjectIdVersionAssembled(string id, string channelId, string projectVariableSetSnapshotId, string projectDeploymentProcessSnapshotId, string jSON, string projectId, string version, DateTimeOffset assembled)
                {
                        var records = await this.Where(x => x.Id == id && x.ChannelId == channelId && x.ProjectVariableSetSnapshotId == projectVariableSetSnapshotId && x.ProjectDeploymentProcessSnapshotId == projectDeploymentProcessSnapshotId && x.JSON == jSON && x.ProjectId == projectId && x.Version == version && x.Assembled == assembled);

                        return records;
                }

                protected async Task<List<Release>> Where(
                        Expression<Func<Release, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<Release, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<Release>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Release>();
                        }
                        else
                        {
                                return await this.Context.Set<Release>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Release>();
                        }
                }

                private async Task<Release> GetById(string id)
                {
                        List<Release> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>5177522c9c3b4e6387b48b3335795538</Hash>
</Codenesium>*/