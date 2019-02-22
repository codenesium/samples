using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IOfficerCapabilityService
	{
		Task<CreateResponse<ApiOfficerCapabilityServerResponseModel>> Create(
			ApiOfficerCapabilityServerRequestModel model);

		Task<UpdateResponse<ApiOfficerCapabilityServerResponseModel>> Update(int id,
		                                                                      ApiOfficerCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOfficerCapabilityServerResponseModel> Get(int id);

		Task<List<ApiOfficerCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiOfficerRefCapabilityServerResponseModel>> OfficerRefCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>1ca1b982b350553ad74da8815a0d01a7</Hash>
</Codenesium>*/