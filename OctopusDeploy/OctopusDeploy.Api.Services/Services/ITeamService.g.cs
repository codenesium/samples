using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ITeamService
        {
                Task<CreateResponse<ApiTeamResponseModel>> Create(
                        ApiTeamRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiTeamRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiTeamResponseModel> Get(string id);

                Task<List<ApiTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTeamResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>b56ac67fac65cb6b7d36b71841d71067</Hash>
</Codenesium>*/