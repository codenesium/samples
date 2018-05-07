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
		Task<CreateResponse<int>> Create(
			AirTransportModel model);

		Task<ActionResponse> Update(int airlineId,
		                            AirTransportModel model);

		Task<ActionResponse> Delete(int airlineId);

		POCOAirTransport Get(int airlineId);

		List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a8f5199ab9861fe6f18817b24b0bc6ca</Hash>
</Codenesium>*/