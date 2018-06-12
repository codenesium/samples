using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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

                Task<List<ApiProxyResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiProxyResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>d57cbe2ccfb43cc3e4c2cbe0c4869a27</Hash>
</Codenesium>*/