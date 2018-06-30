using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiAccountResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiAccountResponseModel> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>1512232b208a3b4c1a96dd87de2aa0b6</Hash>
</Codenesium>*/