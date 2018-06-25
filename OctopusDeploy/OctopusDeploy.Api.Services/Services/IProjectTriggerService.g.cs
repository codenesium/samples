using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IProjectTriggerService
        {
                Task<CreateResponse<ApiProjectTriggerResponseModel>> Create(
                        ApiProjectTriggerRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiProjectTriggerRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProjectTriggerResponseModel> Get(string id);

                Task<List<ApiProjectTriggerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProjectTriggerResponseModel> ByProjectIdName(string projectId, string name);

                Task<List<ApiProjectTriggerResponseModel>> ByProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>6cdec392743e7d5f7cc7509bd528c977</Hash>
</Codenesium>*/