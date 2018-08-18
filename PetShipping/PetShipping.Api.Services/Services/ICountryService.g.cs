using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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

		Task<List<ApiCountryRequirementResponseModel>> CountryRequirements(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDestinationResponseModel>> Destinations(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>b4e48eedf353797cbfcf2955cf73d13d</Hash>
</Codenesium>*/