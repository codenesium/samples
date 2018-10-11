using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IAirTransportRepository
	{
		Task<AirTransport> Create(AirTransport item);

		Task Update(AirTransport item);

		Task Delete(int airlineId);

		Task<AirTransport> Get(int airlineId);

		Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0);

		Task<Handler> HandlerByHandlerId(int handlerId);
	}
}

/*<Codenesium>
    <Hash>9afa42ce85548109470dcb06c665370f</Hash>
</Codenesium>*/