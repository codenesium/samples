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
			ApiAirTransportModel model);

		Task<ActionResponse> Update(int airlineId,
		                            ApiAirTransportModel model);

		Task<ActionResponse> Delete(int airlineId);

		POCOAirTransport Get(int airlineId);

		List<POCOAirTransport> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4a28c9de5f27c4f1e33ad8b062703427</Hash>
</Codenesium>*/