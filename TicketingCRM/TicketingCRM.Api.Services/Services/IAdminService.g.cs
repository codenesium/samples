using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IAdminService
	{
		Task<CreateResponse<ApiAdminResponseModel>> Create(
			ApiAdminRequestModel model);

		Task<UpdateResponse<ApiAdminResponseModel>> Update(int id,
		                                                    ApiAdminRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAdminResponseModel> Get(int id);

		Task<List<ApiAdminResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueResponseModel>> VenuesByAdminId(int adminId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>256558dd4e3524640c1f3e02cbc9c55b</Hash>
</Codenesium>*/