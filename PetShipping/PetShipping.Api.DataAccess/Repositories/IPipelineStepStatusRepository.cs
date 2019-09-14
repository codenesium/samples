using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepStatusRepository
	{
		Task<PipelineStepStatus> Create(PipelineStepStatus item);

		Task Update(PipelineStepStatus item);

		Task Delete(int id);

		Task<PipelineStepStatus> Get(int id);

		Task<List<PipelineStepStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PipelineStep>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2229ace34ec3e0238209e639dcf358f6</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/