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

		Task<UpdateResponse<ApiOfficerCapabilitiesServerResponseModel>> Update(int id,
		                                                                        ApiOfficerCapabilitiesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOfficerCapabilitiesServerResponseModel> Get(int id);

		Task<List<ApiOfficerCapabilitiesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>e59c9444e685b84d6f8caf5c3f14dd15</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/