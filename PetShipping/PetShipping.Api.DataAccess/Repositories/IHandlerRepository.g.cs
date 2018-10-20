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

		Task<List<AirTransport>> AirTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<Handler>> ByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>50d5053f34ee9914aa95228da0a95e78</Hash>
</Codenesium>*/