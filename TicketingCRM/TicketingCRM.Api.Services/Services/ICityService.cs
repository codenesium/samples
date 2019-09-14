using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ICityService
	{
		Task<CreateResponse<ApiCityServerResponseModel>> Create(
			ApiCityServerRequestModel model);

		Task<UpdateResponse<ApiCityServerResponseModel>> Update(int id,
		                                                         ApiCityServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCityServerResponseModel> Get(int id);

		Task<List<ApiCityServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCityServerResponseModel>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventServerResponseModel>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>73c445950fcfc1f80aea99a521b6aa60</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/