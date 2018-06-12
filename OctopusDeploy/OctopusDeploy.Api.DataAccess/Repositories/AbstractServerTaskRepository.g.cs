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
        public abstract class AbstractServerTaskRepository: AbstractRepository
        {
                protected ApplicationDbContext Context { get; }

                protected ILogger Logger { get; }

                public AbstractServerTaskRepository(
                        ILogger logger,
                        ApplicationDbContext context)
                        : base ()
                {
                        this.Logger = logger;
                        this.Context = context;
                }

                public virtual Task<List<ServerTask>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        return this.SearchLinqEF(x => true, skip, take, orderClause);
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

                public async Task<List<ServerTask>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTime queueTime, Nullable<DateTime> startTime, Nullable<DateTime> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId)
                {
                        var records = await this.SearchLinqEF(x => x.Description == description && x.QueueTime == queueTime && x.StartTime == startTime && x.CompletedTime == completedTime && x.ErrorMessage == errorMessage && x.ConcurrencyTag == concurrencyTag && x.HasPendingInterruptions == hasPendingInterruptions && x.HasWarningsOrErrors == hasWarningsOrErrors && x.DurationSeconds == durationSeconds && x.JSON == jSON && x.State == state && x.Name == name && x.ProjectId == projectId && x.EnvironmentId == environmentId && x.TenantId == tenantId && x.ServerNodeId == serverNodeId);

                        return records;
                }
                public async Task<List<ServerTask>> GetStateConcurrencyTag(string state, string concurrencyTag)
                {
                        var records = await this.SearchLinqEF(x => x.State == state && x.ConcurrencyTag == concurrencyTag);

                        return records;
                }
                public async Task<List<ServerTask>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTime> startTime, Nullable<DateTime> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTime queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId)
                {
                        var records = await this.SearchLinqEF(x => x.Name == name && x.Description == description && x.StartTime == startTime && x.CompletedTime == completedTime && x.ErrorMessage == errorMessage && x.HasWarningsOrErrors == hasWarningsOrErrors && x.ProjectId == projectId && x.EnvironmentId == environmentId && x.TenantId == tenantId && x.DurationSeconds == durationSeconds && x.JSON == jSON && x.QueueTime == queueTime && x.State == state && x.ConcurrencyTag == concurrencyTag && x.HasPendingInterruptions == hasPendingInterruptions && x.ServerNodeId == serverNodeId);

                        return records;
                }

                protected async Task<List<ServerTask>> Where(Expression<Func<ServerTask, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        List<ServerTask> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

                        return records;
                }

                private async Task<List<ServerTask>> SearchLinqEF(Expression<Func<ServerTask, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ServerTask.Id)} ASC";
                        }

                        return await this.Context.Set<ServerTask>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ServerTask>();
                }

                private async Task<List<ServerTask>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
                {
                        if (string.IsNullOrWhiteSpace(orderClause))
                        {
                                orderClause = $"{nameof(ServerTask.Id)} ASC";
                        }

                        return await this.Context.Set<ServerTask>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ServerTask>();
                }

                private async Task<ServerTask> GetById(string id)
                {
                        List<ServerTask> records = await this.SearchLinqEF(x => x.Id == id);

                        return records.FirstOrDefault();
                }
        }
}

/*<Codenesium>
    <Hash>05ed2aa273758fef53a8ff0fe44ba775</Hash>
</Codenesium>*/