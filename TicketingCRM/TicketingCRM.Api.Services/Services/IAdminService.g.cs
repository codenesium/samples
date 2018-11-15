using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IAdminService
	{
		Task<CreateResponse<ApiAdminServerResponseModel>> Create(
			ApiAdminServerRequestModel model);

		Task<UpdateResponse<ApiAdminServerResponseModel>> Update(int id,
		                                                          ApiAdminServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAdminServerResponseModel> Get(int id);

		Task<List<ApiAdminServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueServerResponseModel>> VenuesByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7a4d20f4d3871af05edd8743f52e5183</Hash>
</Codenesium>*/