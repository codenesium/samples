using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBODestination
	{
		Task<CreateResponse<ApiDestinationResponseModel>> Create(
			ApiDestinationRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiDestinationRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiDestinationResponseModel> Get(int id);

		Task<List<ApiDestinationResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1ec70e43d8745704bfe9abef335cb83b</Hash>
</Codenesium>*/