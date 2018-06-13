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

                Task<List<ServerTask>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<ServerTask>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId);
                Task<List<ServerTask>> GetStateConcurrencyTag(string state, string concurrencyTag);
                Task<List<ServerTask>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId);
        }
}

/*<Codenesium>
    <Hash>8d32f0fcd1243d0f7125d6c6e342a443</Hash>
</Codenesium>*/