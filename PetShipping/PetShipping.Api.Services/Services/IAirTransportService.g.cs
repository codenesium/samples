using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public interface IAirTransportService
	{
		Task<CreateResponse<ApiAirTransportResponseModel>> Create(
			ApiAirTransportRequestModel model);

		Task<ActionResponse> Update(int airlineId,
		                            ApiAirTransportRequestModel model);

		Task<ActionResponse> Delete(int airlineId);

		Task<ApiAirTransportResponseModel> Get(int airlineId);

		Task<List<ApiAirTransportResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>788c7687b599b1fe62a5dd5adeff7c2f</Hash>
</Codenesium>*/