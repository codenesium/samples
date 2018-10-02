using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITenantService
	{
		Task<CreateResponse<ApiTenantResponseModel>> Create(
			ApiTenantRequestModel model);

		Task<UpdateResponse<ApiTenantResponseModel>> Update(int id,
		                                                     ApiTenantRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTenantResponseModel> Get(int id);

		Task<List<ApiTenantResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>15e1b10b83d00220cca475acbc540e85</Hash>
</Codenesium>*/