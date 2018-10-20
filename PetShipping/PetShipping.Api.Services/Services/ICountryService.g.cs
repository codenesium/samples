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

		Task<List<ApiCountryRequirementResponseModel>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDestinationResponseModel>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>80638d468f8790c44c5faea44eace1b9</Hash>
</Codenesium>*/