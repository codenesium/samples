using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IDestinationService
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
    <Hash>5a816e69591c9ea03b793fb307e5da55</Hash>
</Codenesium>*/