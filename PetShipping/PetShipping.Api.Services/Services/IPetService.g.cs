using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IPetService
	{
		Task<CreateResponse<ApiPetResponseModel>> Create(
			ApiPetRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPetRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPetResponseModel> Get(int id);

		Task<List<ApiPetResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1a3a2f81cd028e8e46ce80982b60d064</Hash>
</Codenesium>*/