using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface ITenantService
        {
                Task<CreateResponse<ApiTenantResponseModel>> Create(
                        ApiTenantRequestModel model);

                Task<ActionResponse> Update(string id,
                                            ApiTenantRequestModel model);

                Task<ActionResponse> Delete(string id);

                Task<ApiTenantResponseModel> Get(string id);

                Task<List<ApiTenantResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<ApiTenantResponseModel> GetName(string name);
                Task<List<ApiTenantResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>eb25a81a1f2e2b7808e87d1afebc3039</Hash>
</Codenesium>*/