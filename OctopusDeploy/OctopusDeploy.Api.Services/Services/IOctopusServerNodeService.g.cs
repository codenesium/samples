using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IOctopusServerNodeService
        {
                Task<CreateResponse<ApiOctopusServerNodeResponseModel>> Create(
                        ApiOctopusServerNodeRequestModel model);

                Task<UpdateResponse<ApiOctopusServerNodeResponseModel>> Update(string id,
                                                                                ApiOctopusServerNodeRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiOctopusServerNodeResponseModel> Get(string id);

                Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>84b5d733f9d205de1afc6167e76b5d88</Hash>
</Codenesium>*/