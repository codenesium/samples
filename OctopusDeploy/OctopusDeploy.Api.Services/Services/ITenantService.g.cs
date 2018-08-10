using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial interface ITenantService
	{
		Task<CreateResponse<ApiTenantResponseModel>> Create(
			ApiTenantRequestModel model);

		Task<UpdateResponse<ApiTenantResponseModel>> Update(string id,
		                                                     ApiTenantRequestModel model);

		Task<ActionResponse> Delete(string id);

		Task<ApiTenantResponseModel> Get(string id);

		Task<List<ApiTenantResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<ApiTenantResponseModel> ByName(string name);

		Task<List<ApiTenantResponseModel>> ByDataVersion(byte[] dataVersion);
	}
}

/*<Codenesium>
    <Hash>88d66382fdd6adc90529bb292f26f457</Hash>
</Codenesium>*/