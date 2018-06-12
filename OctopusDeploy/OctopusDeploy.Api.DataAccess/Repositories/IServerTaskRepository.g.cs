using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IServerTaskRepository
        {
                Task<ServerTask> Create(ServerTask item);

                Task Update(ServerTask item);

                Task Delete(string id);

                Task<ServerTask> Get(string id);

                Task<List<ServerTask>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ServerTask>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTime queueTime, Nullable<DateTime> startTime, Nullable<DateTime> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId);
                Task<List<ServerTask>> GetStateConcurrencyTag(string state, string concurrencyTag);
                Task<List<ServerTask>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTime> startTime, Nullable<DateTime> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTime queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId);
        }
}

/*<Codenesium>
    <Hash>5e49f7086c67cd45e6464374167d29f0</Hash>
</Codenesium>*/