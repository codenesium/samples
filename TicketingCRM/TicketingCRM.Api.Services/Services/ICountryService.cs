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

		Task<List<ApiCountryServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiProvinceServerResponseModel>> ProvincesByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>22276b126a98858af168373218dd5839</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/