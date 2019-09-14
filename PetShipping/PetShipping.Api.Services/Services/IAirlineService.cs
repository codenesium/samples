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

		Task<List<ApiAirlineServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>4edb6b94b6b1a2fad6f2b707cd3b6cf2</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/