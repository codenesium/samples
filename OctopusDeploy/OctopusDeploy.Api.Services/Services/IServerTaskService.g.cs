using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IServerTaskService
        {
                Task<CreateResponse<ApiServerTaskResponseModel>> Create(
                        ApiServerTaskRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiServerTaskRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiServerTaskResponseModel> Get(string id);

                Task<List<ApiServerTaskResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiServerTaskResponseModel>> ByDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId);

                Task<List<ApiServerTaskResponseModel>> ByStateConcurrencyTag(string state, string concurrencyTag);

                Task<List<ApiServerTaskResponseModel>> ByNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, DateTimeOffset? startTime, DateTimeOffset? completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId);
        }
}

/*<Codenesium>
    <Hash>7bf8906f4473d02924b804f9057cf5e3</Hash>
</Codenesium>*/