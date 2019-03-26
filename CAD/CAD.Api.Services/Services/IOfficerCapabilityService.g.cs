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

		Task<UpdateResponse<ApiOfficerCapabilityServerResponseModel>> Update(int capabilityId,
		                                                                      ApiOfficerCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int capabilityId);

		Task<ApiOfficerCapabilityServerResponseModel> Get(int capabilityId);

		Task<List<ApiOfficerCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiOfficerCapabilityServerResponseModel>> ByOfficerId(int capabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>92d4e26531d9f1a6bc8f0968d1306b17</Hash>
</Codenesium>*/