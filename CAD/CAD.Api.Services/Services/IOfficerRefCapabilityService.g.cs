using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IOfficerRefCapabilityService
	{
		Task<CreateResponse<ApiOfficerRefCapabilityServerResponseModel>> Create(
			ApiOfficerRefCapabilityServerRequestModel model);

		Task<UpdateResponse<ApiOfficerRefCapabilityServerResponseModel>> Update(int id,
		                                                                         ApiOfficerRefCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOfficerRefCapabilityServerResponseModel> Get(int id);

		Task<List<ApiOfficerRefCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>00905045dd49405ec0a45b8c9d9d2662</Hash>
</Codenesium>*/