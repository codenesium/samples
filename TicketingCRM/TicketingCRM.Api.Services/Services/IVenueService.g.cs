using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IVenueService
	{
		Task<CreateResponse<ApiVenueResponseModel>> Create(
			ApiVenueRequestModel model);

		Task<UpdateResponse<ApiVenueResponseModel>> Update(int id,
		                                                    ApiVenueRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVenueResponseModel> Get(int id);

		Task<List<ApiVenueResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueResponseModel>> ByAdminId(int adminId);

		Task<List<ApiVenueResponseModel>> ByProvinceId(int provinceId);
	}
}

/*<Codenesium>
    <Hash>05d335077f533c3fe187db0f62e88875</Hash>
</Codenesium>*/