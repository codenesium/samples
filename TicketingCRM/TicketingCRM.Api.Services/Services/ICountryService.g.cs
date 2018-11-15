using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ICountryService
	{
		Task<CreateResponse<ApiCountryServerResponseModel>> Create(
			ApiCountryServerRequestModel model);

		Task<UpdateResponse<ApiCountryServerResponseModel>> Update(int id,
		                                                            ApiCountryServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCountryServerResponseModel> Get(int id);

		Task<List<ApiCountryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProvinceServerResponseModel>> ProvincesByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>535cae7b895b941be90c9b841c093a2b</Hash>
</Codenesium>*/