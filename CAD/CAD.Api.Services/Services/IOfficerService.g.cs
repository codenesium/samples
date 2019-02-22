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

		Task<List<ApiOfficerRefCapabilityServerResponseModel>> OfficerRefCapabilitiesByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiUnitOfficerServerResponseModel>> UnitOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVehicleOfficerServerResponseModel>> VehicleOfficersByOfficerId(int officerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bb94224eeb855568779a2783fbe623b1</Hash>
</Codenesium>*/