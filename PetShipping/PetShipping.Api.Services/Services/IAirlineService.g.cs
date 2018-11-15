using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IAirlineService
	{
		Task<CreateResponse<ApiAirlineServerResponseModel>> Create(
			ApiAirlineServerRequestModel model);

		Task<UpdateResponse<ApiAirlineServerResponseModel>> Update(int id,
		                                                            ApiAirlineServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiAirlineServerResponseModel> Get(int id);

		Task<List<ApiAirlineServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0df2eb6043a95c5d0539217ea39d869c</Hash>
</Codenesium>*/