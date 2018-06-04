using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IBreedService
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
    <Hash>48ce7d7efec14734edd1a16c6d405c3d</Hash>
</Codenesium>*/