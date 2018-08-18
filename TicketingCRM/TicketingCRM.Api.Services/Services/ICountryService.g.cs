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

		Task<List<ApiProvinceResponseModel>> Provinces(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>bdab6ce7120c1a0d04dd129cebab7124</Hash>
</Codenesium>*/