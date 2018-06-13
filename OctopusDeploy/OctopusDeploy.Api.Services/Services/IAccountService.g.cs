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

                Task<List<ApiAccountResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiAccountResponseModel> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>e7b1fc46a9b7d475620f4c037513accc</Hash>
</Codenesium>*/