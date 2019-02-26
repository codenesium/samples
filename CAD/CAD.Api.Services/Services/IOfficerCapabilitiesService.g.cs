using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IOfficerCapabilitiesService
	{
		Task<CreateResponse<ApiOfficerCapabilitiesServerResponseModel>> Create(
			ApiOfficerCapabilitiesServerRequestModel model);

		Task<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>> Update(int capabilityId,
		                                                                        ApiOfficerCapabilitiesServerRequestModel model);

		Task<ActionResponse> Delete(int capabilityId);

		Task<ApiOfficerCapabilitiesServerResponseModel> Get(int capabilityId);

		Task<List<ApiOfficerCapabilitiesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>e0cb21466a87905159053419454871ff</Hash>
</Codenesium>*/