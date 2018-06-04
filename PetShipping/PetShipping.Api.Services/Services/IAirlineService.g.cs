using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IAirlineService
	{
		Task<CreateResponse<ApiAirlineResponseModel>> Create(
			ApiAirlineRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiAirlineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAirlineResponseModel> Get(int id);

		Task<List<ApiAirlineResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f99ea33eda2e9eacb3190e45fa0e21e9</Hash>
</Codenesium>*/