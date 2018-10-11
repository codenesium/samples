using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IHandlerRepository
	{
		Task<Handler> Create(Handler item);

		Task Update(Handler item);

		Task Delete(int id);

		Task<Handler> Get(int id);

		Task<List<Handler>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<AirTransport>> AirTransports(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<Handler>> ByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>852d6077c9799c0ed4397bdfc2d19f80</Hash>
</Codenesium>*/