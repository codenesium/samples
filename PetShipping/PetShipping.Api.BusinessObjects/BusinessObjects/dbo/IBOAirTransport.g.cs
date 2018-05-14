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
		Task<CreateResponse<POCOAirTransport>> Create(
			AirTransportModel model);

		Task<ActionResponse> Update(int airlineId,
		                            AirTransportModel model);

		Task<ActionResponse> Delete(int airlineId);

		POCOAirTransport Get(int airlineId);

		List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4dcfb8b284442e1c0b9b5ce6f9f5f7b7</Hash>
</Codenesium>*/