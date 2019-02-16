using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IVenueService
	{
		Task<CreateResponse<ApiVenueServerResponseModel>> Create(
			ApiVenueServerRequestModel model);

		Task<UpdateResponse<ApiVenueServerResponseModel>> Update(int id,
		                                                          ApiVenueServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVenueServerResponseModel> Get(int id);

		Task<List<ApiVenueServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiVenueServerResponseModel>> ByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueServerResponseModel>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>58bb0e832f6fa3640d1aa46561bef0d6</Hash>
</Codenesium>*/