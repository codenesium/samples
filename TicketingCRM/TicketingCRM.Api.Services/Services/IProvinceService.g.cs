using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IProvinceService
	{
		Task<CreateResponse<ApiProvinceResponseModel>> Create(
			ApiProvinceRequestModel model);

		Task<UpdateResponse<ApiProvinceResponseModel>> Update(int id,
		                                                       ApiProvinceRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiProvinceResponseModel> Get(int id);

		Task<List<ApiProvinceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProvinceResponseModel>> ByCountryId(int countryId);

		Task<List<ApiCityResponseModel>> Cities(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueResponseModel>> Venues(int provinceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c9bdae698f917c46b6a609576bc5e0e0</Hash>
</Codenesium>*/