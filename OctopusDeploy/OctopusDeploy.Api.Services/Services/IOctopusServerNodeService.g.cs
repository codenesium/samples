using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IOctopusServerNodeService
        {
                Task<CreateResponse<ApiOctopusServerNodeResponseModel>> Create(
                        ApiOctopusServerNodeRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiOctopusServerNodeRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiOctopusServerNodeResponseModel> Get(string id);

                Task<List<ApiOctopusServerNodeResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>16ffc23d61aa5d41dc7b7b9c8d9aca85</Hash>
</Codenesium>*/