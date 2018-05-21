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

		Task<POCOAirTransport> Get(int airlineId);

		Task<List<POCOAirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>38ceb978b262ebd4d9464f4486dec860</Hash>
</Codenesium>*/