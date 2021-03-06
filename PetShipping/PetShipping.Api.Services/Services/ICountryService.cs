using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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

		Task<List<ApiCountryRequirementServerResponseModel>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiDestinationServerResponseModel>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>dd04bc5a58140e9d033a41837a23b4e7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/