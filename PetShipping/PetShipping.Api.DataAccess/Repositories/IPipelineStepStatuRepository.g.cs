using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStepStatuRepository
	{
		Task<PipelineStepStatu> Create(PipelineStepStatu item);

		Task Update(PipelineStepStatu item);

		Task Delete(int id);

		Task<PipelineStepStatu> Get(int id);

		Task<List<PipelineStepStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<PipelineStep>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>58d7e544dfcf933fa7988beaf32e79b9</Hash>
</Codenesium>*/