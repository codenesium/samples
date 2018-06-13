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

                Task<List<ApiTenantResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<ApiTenantResponseModel> GetName(string name);
                Task<List<ApiTenantResponseModel>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>10c12f808e92d27e3467479639558d0a</Hash>
</Codenesium>*/