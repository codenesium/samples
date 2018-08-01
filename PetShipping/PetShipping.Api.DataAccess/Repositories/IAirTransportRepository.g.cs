using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirTransportRepository
	{
		Task<AirTransport> Create(AirTransport item);

		Task Update(AirTransport item);

		Task Delete(int airlineId);

		Task<AirTransport> Get(int airlineId);

		Task<List<AirTransport>> All(int limit = int.MaxValue, int offset = 0);

		Task<Handler> GetHandler(int handlerId);
	}
}

/*<Codenesium>
    <Hash>d7b1d52de9aba3687b27bc5577196690</Hash>
</Codenesium>*/