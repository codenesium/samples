using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiProjectTriggerResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiProjectTriggerResponseModel> GetProjectIdName(string projectId, string name);
                Task<List<ApiProjectTriggerResponseModel>> GetProjectId(string projectId);
        }
}

/*<Codenesium>
    <Hash>3847d76e3facdea14a15c888b38bb910</Hash>
</Codenesium>*/