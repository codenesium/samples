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

		Task<List<HandlerPipelineStep>> HandlerPipelineStepsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);

		Task<List<OtherTransport>> OtherTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f7e66bc79ce2e9648965fe1763dbf274</Hash>
</Codenesium>*/