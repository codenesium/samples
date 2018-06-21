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
        public abstract class AbstractServerTaskRepository : AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractServerTaskRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ServerTask>> All(int limit = int.MaxValue, int offset = 0)
                {
                        return this.Where(x => true, limit, offset);
                }

                public async virtual Task<ServerTask> Get(string id)
                {
                        return await this.GetById(id);
                }

                public async virtual Task<ServerTask> Create(ServerTask item)
                {
                        this.Context.Set<ServerTask>().Add(item);
                        await this.Context.SaveChangesAsync();

                        this.Context.Entry(item).State = EntityState.Detached;
                        return item;
                }

                public async virtual Task Update(ServerTask item)
                {
                        var entity = this.Context.Set<ServerTask>().Local.FirstOrDefault(x => x.Id == item.Id);
                        if (entity == null)
                        {
                                this.Context.Set<ServerTask>().Attach(item);
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
                        ServerTask record = await this.GetById(id);

                        if (record == null)
                        {
                                return;
                        }
                        else
                        {
                                this.Context.Set<ServerTask>().Remove(record);
                                await this.Context.SaveChangesAsync();
                        }
                }

                public async Task<List<ServerTask>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
                {
                        var records = await this.Where(x => x.Description == description && x.QueueTime == queueTime && x.StartTime == startTime && x.CompletedTime == completedTime && x.ErrorMessage == errorMessage && x.ConcurrencyTag == concurrencyTag && x.HasPendingInterruptions == hasPendingInterruptions && x.HasWarningsOrErrors == hasWarningsOrErrors && x.DurationSeconds == durationSeconds && x.JSON == jSON && x.State == state && x.Name == name && x.ProjectId == projectId && x.EnvironmentId == environmentId && x.TenantId == tenantId && x.ServerNodeId == serverNodeId);

                        return records;
                }

                public async Task<List<ServerTask>> GetStateConcurrencyTag(string state, string concurrencyTag)
                {
                        var records = await this.Where(x => x.State == state && x.ConcurrencyTag == concurrencyTag);

                        return records;
                }

                public async Task<List<ServerTask>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
                {
                        var records = await this.Where(x => x.Name == name && x.Description == description && x.StartTime == startTime && x.CompletedTime == completedTime && x.ErrorMessage == errorMessage && x.HasWarningsOrErrors == hasWarningsOrErrors && x.ProjectId == projectId && x.EnvironmentId == environmentId && x.TenantId == tenantId && x.DurationSeconds == durationSeconds && x.JSON == jSON && x.QueueTime == queueTime && x.State == state && x.ConcurrencyTag == concurrencyTag && x.HasPendingInterruptions == hasPendingInterruptions && x.ServerNodeId == serverNodeId);

                        return records;
                }

                protected async Task<List<ServerTask>> Where(
                        Expression<Func<ServerTask, bool>> predicate,
                        int limit = int.MaxValue,
                        int offset = 0,
                        Expression<Func<ServerTask, dynamic>> orderBy = null,
                        ListSortDirection sortDirection = ListSortDirection.Ascending)
                {
                        if (orderBy == null)
                        {
                                orderBy = x => x.Id;
                        }

                        if (sortDirection == ListSortDirection.Ascending)
                        {
                                return await this.Context.Set<ServerTask>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ServerTask>();
                        }
                        else
                        {
                                return await this.Context.Set<ServerTask>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ServerTask>();
                        }
                }

                private async Task<ServerTask> GetById(string id)
                {
                        List<ServerTask> records = await this.Where(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>fab2e5826f74a85c21c7915da2a2e898</Hash>
</Codenesium>*/