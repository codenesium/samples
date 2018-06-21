using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IProxyService
        {
                Task<CreateResponse<ApiProxyResponseModel>> Create(
                        ApiProxyRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiProxyRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProxyResponseModel> Get(string id);

                Task<List<ApiProxyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProxyResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>a938d3e6671369749fc9d3b0d550bb00</Hash>
</Codenesium>*/