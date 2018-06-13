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

                Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>b5bf3ac43f8d0b75e7d1361d62ebc0d0</Hash>
</Codenesium>*/