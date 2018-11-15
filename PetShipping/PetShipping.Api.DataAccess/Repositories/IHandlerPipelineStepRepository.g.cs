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

		Task<Handler> HandlerByHandlerId(int handlerId);

		Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId);
	}
}

/*<Codenesium>
    <Hash>811651e0ed419e0ca214a4367b419383</Hash>
</Codenesium>*/