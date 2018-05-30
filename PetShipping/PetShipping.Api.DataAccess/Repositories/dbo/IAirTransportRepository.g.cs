using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		Task<DTOAirTransport> Create(DTOAirTransport dto);

		Task Update(int airlineId,
		            DTOAirTransport dto);

		Task Delete(int airlineId);

		Task<DTOAirTransport> Get(int airlineId);

		Task<List<DTOAirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0810360343cdc5b64b56e597227b9283</Hash>
</Codenesium>*/