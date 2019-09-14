using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface ISpeciesService
	{
		Task<CreateResponse<ApiSpeciesServerResponseModel>> Create(
			ApiSpeciesServerRequestModel model);

		Task<UpdateResponse<ApiSpeciesServerResponseModel>> Update(int id,
		                                                            ApiSpeciesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSpeciesServerResponseModel> Get(int id);

		Task<List<ApiSpeciesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiBreedServerResponseModel>> BreedsBySpeciesId(int speciesId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e2293d75a747edc2c8f432cb3a8cac4a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/