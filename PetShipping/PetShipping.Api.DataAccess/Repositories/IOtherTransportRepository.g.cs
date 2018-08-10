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

		Task<List<OtherTransport>> All(int limit = int.MaxValue, int offset = 0);

		Task<Handler> GetHandler(int handlerId);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>fa71bbafaefe7590896044de938fdeee</Hash>
</Codenesium>*/