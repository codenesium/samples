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

                Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>61c01391003b321a9628c5c61141a6ad</Hash>
</Codenesium>*/