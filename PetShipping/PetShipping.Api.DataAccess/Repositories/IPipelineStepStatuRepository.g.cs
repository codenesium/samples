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

		Task<List<PipelineStepStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<PipelineStep>> PipelineStepsByPipelineStepStatusId(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>52725437029e263b75fafe49a9cf5d1e</Hash>
</Codenesium>*/