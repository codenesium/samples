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

		Task<List<PipelineStep>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e0d54fedec47288f0ce59ae901f7772b</Hash>
</Codenesium>*/