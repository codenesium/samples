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

                Task<List<ApiTeamResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiTeamResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>7fceb7d1df8591b094b3fd926202c24e</Hash>
</Codenesium>*/