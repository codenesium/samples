using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
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
    <Hash>2ef1815c197c6a7146a0d0f368bd2c20</Hash>
</Codenesium>*/