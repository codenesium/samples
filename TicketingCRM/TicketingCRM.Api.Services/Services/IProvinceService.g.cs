using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IProvinceService
	{
		Task<CreateResponse<ApiProvinceServerResponseModel>> Create(
			ApiProvinceServerRequestModel model);

		Task<UpdateResponse<ApiProvinceServerResponseModel>> Update(int id,
		                                                             ApiProvinceServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiProvinceServerResponseModel> Get(int id);

		Task<List<ApiProvinceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProvinceServerResponseModel>> ByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCityServerResponseModel>> CitiesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiVenueServerResponseModel>> VenuesByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>175d85fbafc5f63f45e71bf4d9c00363</Hash>
</Codenesium>*/