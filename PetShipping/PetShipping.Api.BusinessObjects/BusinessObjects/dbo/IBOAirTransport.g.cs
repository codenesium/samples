using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOAirTransport
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
    <Hash>f36c582929e4a8b2178c9eacdff8e635</Hash>
</Codenesium>*/