using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface ICountryService
	{
		Task<CreateResponse<ApiCountryResponseModel>> Create(
			ApiCountryRequestModel model);

		Task<UpdateResponse<ApiCountryResponseModel>> Update(int id,
		                                                      ApiCountryRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCountryResponseModel> Get(int id);

		Task<List<ApiCountryResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiProvinceResponseModel>> ProvincesByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>11b8be936c0952691e11699f32dd6489</Hash>
</Codenesium>*/