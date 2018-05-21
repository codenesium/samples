using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		Task<POCOAirTransport> Create(ApiAirTransportModel model);

		Task Update(int airlineId,
		            ApiAirTransportModel model);

		Task Delete(int airlineId);

		Task<POCOAirTransport> Get(int airlineId);

		Task<List<POCOAirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8c4a479d60f2f63cabc2ba229136cd26</Hash>
</Codenesium>*/