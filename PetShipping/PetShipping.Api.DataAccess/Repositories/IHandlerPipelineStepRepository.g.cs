using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
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
    <Hash>c96f6c74bb623b18b59e29507643eb77</Hash>
</Codenesium>*/