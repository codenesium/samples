using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IServerTaskRepository
        {
                Task<ServerTask> Create(ServerTask item);

                Task Update(ServerTask item);

                Task Delete(string id);

                Task<ServerTask> Get(string id);

                Task<List<ServerTask>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ServerTask>> ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId);

                Task<List<ServerTask>> ByStateConcurrencyTag(string state, string concurrencyTag);

                Task<List<ServerTask>> ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId);
        }
}

/*<Codenesium>
    <Hash>ae42d7c11d46e9410ed74251a786947d</Hash>
</Codenesium>*/