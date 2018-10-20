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

		Task<List<ApiProvinceResponseModel>> ByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCityResponseModel>> CitiesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueResponseModel>> VenuesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d72e81bfde0457a3942aaed8699424c5</Hash>
</Codenesium>*/