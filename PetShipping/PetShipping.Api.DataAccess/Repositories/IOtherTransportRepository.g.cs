using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IOtherTransportRepository
	{
		Task<OtherTransport> Create(OtherTransport item);

		Task Update(OtherTransport item);

		Task Delete(int id);

		Task<OtherTransport> Get(int id);

		Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset = 0);

		Task<Handler> GetHandler(int handlerId);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>6d1cb5f803410fb26ceb8893a35cbf39</Hash>
</Codenesium>*/