using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IAirlineService
	{
		Task<CreateResponse<ApiAirlineResponseModel>> Create(
			ApiAirlineRequestModel model);

		Task<UpdateResponse<ApiAirlineResponseModel>> Update(int id,
		                                                      ApiAirlineRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAirlineResponseModel> Get(int id);

		Task<List<ApiAirlineResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2fc64aa8784e0768309adb3ccf7b79ad</Hash>
</Codenesium>*/