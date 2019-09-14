using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IOffCapabilityService
	{
		Task<CreateResponse<ApiOffCapabilityServerResponseModel>> Create(
			ApiOffCapabilityServerRequestModel model);

		Task<UpdateResponse<ApiOffCapabilityServerResponseModel>> Update(int id,
		                                                                  ApiOffCapabilityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOffCapabilityServerResponseModel> Get(int id);

		Task<List<ApiOffCapabilityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiOfficerCapabilitiesServerResponseModel>> OfficerCapabilitiesByCapabilityId(int capabilityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0d46edab5b02b0df91dcb9dd4d871462</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/