using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IPetService
	{
		Task<CreateResponse<ApiPetServerResponseModel>> Create(
			ApiPetServerRequestModel model);

		Task<UpdateResponse<ApiPetServerResponseModel>> Update(int id,
		                                                        ApiPetServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPetServerResponseModel> Get(int id);

		Task<List<ApiPetServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiSaleServerResponseModel>> SalesByPetId(int petId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d946eda40cb94d45ce78ccb388eb28f5</Hash>
</Codenesium>*/