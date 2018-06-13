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

                Task<List<ApiServerTaskResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiServerTaskResponseModel>> GetDescriptionQueueTimeStartTimeCompletedTimeErrorMessageConcurrencyTagHasPendingInterruptionsHasWarningsOrErrorsDurationSecondsJSONStateNameProjectIdEnvironmentIdTenantIdServerNodeId(string description, DateTimeOffset queueTime, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, string concurrencyTag, bool hasPendingInterruptions, bool hasWarningsOrErrors, int durationSeconds, string jSON, string state, string name, string projectId, string environmentId, string tenantId, string serverNodeId);
                Task<List<ApiServerTaskResponseModel>> GetStateConcurrencyTag(string state, string concurrencyTag);
                Task<List<ApiServerTaskResponseModel>> GetNameDescriptionStartTimeCompletedTimeErrorMessageHasWarningsOrErrorsProjectIdEnvironmentIdTenantIdDurationSecondsJSONQueueTimeStateConcurrencyTagHasPendingInterruptionsServerNodeId(string name, string description, Nullable<DateTimeOffset> startTime, Nullable<DateTimeOffset> completedTime, string errorMessage, bool hasWarningsOrErrors, string projectId, string environmentId, string tenantId, int durationSeconds, string jSON, DateTimeOffset queueTime, string state, string concurrencyTag, bool hasPendingInterruptions, string serverNodeId);
        }
}

/*<Codenesium>
    <Hash>ce87d83b827df638403de3159f7d6ff8</Hash>
</Codenesium>*/