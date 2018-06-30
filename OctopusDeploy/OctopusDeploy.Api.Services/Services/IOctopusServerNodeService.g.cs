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

                Task<ActionResponse> Update(string id,
                                            ApiOctopusServerNodeRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiOctopusServerNodeResponseModel> Get(string id);

                Task<List<ApiOctopusServerNodeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2cd0b88d0d259dd26fc5c10052cd8e2c</Hash>
</Codenesium>*/