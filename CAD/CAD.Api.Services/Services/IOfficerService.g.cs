using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IOfficerService
	{
		Task<CreateResponse<ApiOfficerServerResponseModel>> Create(
			ApiOfficerServerRequestModel model);

		Task<UpdateResponse<ApiOfficerServerResponseModel>> Update(int id,
		                                                            ApiOfficerServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiOfficerServerResponseModel> Get(int id);

		Task<List<ApiOfficerServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiNoteServerResponseModel>> NotesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiOfficerCapabilityServerResponseModel>> OfficerCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiOfficerServerResponseModel>> ByCapabilityId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiOfficerServerResponseModel>> ByVehicleId(int officerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2bb746d74c140f5e08c52ad021657ed5</Hash>
</Codenesium>*/