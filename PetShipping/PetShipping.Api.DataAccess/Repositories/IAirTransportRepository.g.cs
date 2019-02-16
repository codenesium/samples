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

		Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Handler> HandlerByHandlerId(int handlerId);
	}
}

/*<Codenesium>
    <Hash>e08f4a88f92bb4ff75b93de92a314b75</Hash>
</Codenesium>*/