using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface ILifecycleService
        {
                Task<CreateResponse<ApiLifecycleResponseModel>> Create(
                        ApiLifecycleRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiLifecycleRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiLifecycleResponseModel> Get(string id);

                Task<List<ApiLifecycleResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiLifecycleResponseModel> ByName(string name);

                Task<List<ApiLifecycleResponseModel>> ByDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>9a20306ffc76bf8397401c78f2251528</Hash>
</Codenesium>*/