using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOPet
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
    <Hash>9a209acc558d02f3ff5c7d6b2b51d7ab</Hash>
</Codenesium>*/