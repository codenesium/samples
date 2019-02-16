using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IOtherTransportRepository
	{
		Task<OtherTransport> Create(OtherTransport item);

		Task Update(OtherTransport item);

		Task Delete(int id);

		Task<OtherTransport> Get(int id);

		Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Handler> HandlerByHandlerId(int handlerId);

		Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>fe8afae9f5a0a964500dc71795de5d1c</Hash>
</Codenesium>*/