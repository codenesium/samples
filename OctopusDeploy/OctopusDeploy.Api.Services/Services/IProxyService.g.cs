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

                Task<List<ApiProxyResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiProxyResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>8469be6512d00dd24123962fb285712c</Hash>
</Codenesium>*/