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

                Task<UpdateResponse<ApiProxyResponseModel>> Update(string id,
                                                                    ApiProxyRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiProxyResponseModel> Get(string id);

                Task<List<ApiProxyResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiProxyResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>6d4c2f5af0d059adffa8f55c21df7ee8</Hash>
</Codenesium>*/