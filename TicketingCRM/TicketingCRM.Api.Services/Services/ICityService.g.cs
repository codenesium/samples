using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface ICityService
	{
		Task<CreateResponse<ApiCityResponseModel>> Create(
			ApiCityRequestModel model);

		Task<UpdateResponse<ApiCityResponseModel>> Update(int id,
		                                                   ApiCityRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCityResponseModel> Get(int id);

		Task<List<ApiCityResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCityResponseModel>> ByProvinceId(int provinceId);

		Task<List<ApiEventResponseModel>> Events(int cityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>ff5dcf0b7314c4db59305d47db89ec7b</Hash>
</Codenesium>*/