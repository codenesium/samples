using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ICityService
	{
		Task<CreateResponse<ApiCityResponseModel>> Create(
			ApiCityRequestModel model);

		Task<UpdateResponse<ApiCityResponseModel>> Update(int id,
		                                                   ApiCityRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCityResponseModel> Get(int id);

		Task<List<ApiCityResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiCityResponseModel>> ByProvinceId(int provinceId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventResponseModel>> EventsByCityId(int cityId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>35a5eccc325e54a42b2683163928125f</Hash>
</Codenesium>*/