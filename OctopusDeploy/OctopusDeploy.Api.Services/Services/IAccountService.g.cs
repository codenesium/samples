using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IAccountService
        {
                Task<CreateResponse<ApiAccountResponseModel>> Create(
                        ApiAccountRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiAccountRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiAccountResponseModel> Get(string id);

                Task<List<ApiAccountResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ApiAccountResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>a4ed2e5096f87cdf9994cf08d0dd3a3b</Hash>
</Codenesium>*/