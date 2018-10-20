using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IPetService
	{
		Task<CreateResponse<ApiPetResponseModel>> Create(
			ApiPetRequestModel model);

		Task<UpdateResponse<ApiPetResponseModel>> Update(int id,
		                                                  ApiPetRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPetResponseModel> Get(int id);

		Task<List<ApiPetResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiSaleResponseModel>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>6aec967f2150720c97fedc336a4dd781</Hash>
</Codenesium>*/