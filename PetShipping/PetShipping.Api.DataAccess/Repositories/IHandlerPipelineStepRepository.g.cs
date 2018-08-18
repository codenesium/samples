using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IHandlerPipelineStepRepository
	{
		Task<HandlerPipelineStep> Create(HandlerPipelineStep item);

		Task Update(HandlerPipelineStep item);

		Task Delete(int id);

		Task<HandlerPipelineStep> Get(int id);

		Task<List<HandlerPipelineStep>> All(int limit = int.MaxValue, int offset = 0);

		Task<Handler> GetHandler(int handlerId);

		Task<PipelineStep> GetPipelineStep(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>d18a50a3b23c28fb2b78d6fb85deea4e</Hash>
</Codenesium>*/