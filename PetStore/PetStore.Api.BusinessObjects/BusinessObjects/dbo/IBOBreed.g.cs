using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public interface IBOBreed
	{
		Task<CreateResponse<ApiBreedResponseModel>> Create(
			ApiBreedRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiBreedRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBreedResponseModel> Get(int id);

		Task<List<ApiBreedResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d807f09194494bad5336a944437fefe3</Hash>
</Codenesium>*/