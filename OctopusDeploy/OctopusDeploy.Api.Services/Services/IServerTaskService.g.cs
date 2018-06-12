using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiServerTaskResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<ApiServerTaskResponseModel>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTime queueTime, Nullable<DateTime> startTime, Nullable<DateTime> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId);
                Task<List<ApiServerTaskResponseModel>> GetStateConcurrencyTag(string state, string concurrencyTag);
                Task<List<ApiServerTaskResponseModel>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTime> startTime, Nullable<DateTime> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTime queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId);
        }
}

/*<Codenesium>
    <Hash>1bf576d6d2e08fb768126fde902a7af1</Hash>
</Codenesium>*/