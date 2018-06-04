using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		Task<AirTransport> Create(AirTransport item);

		Task Update(AirTransport item);

		Task Delete(int airlineId);

		Task<AirTransport> Get(int airlineId);

		Task<List<AirTransport>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c5851219626d69f0b4dbac850a4ecaba</Hash>
</Codenesium>*/