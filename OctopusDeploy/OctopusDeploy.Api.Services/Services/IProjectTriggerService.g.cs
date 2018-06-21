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

                Task<ApiProjectTriggerResponseModel> GetProjectIdName(string projectId, string name);

                Task<List<ApiProjectTriggerResponseModel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>6b72d1375d15204b71d5815b27f3ee07</Hash>
</Codenesium>*/