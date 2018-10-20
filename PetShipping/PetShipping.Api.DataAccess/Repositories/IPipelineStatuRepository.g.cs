using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStatuRepository
	{
		Task<PipelineStatu> Create(PipelineStatu item);

		Task Update(PipelineStatu item);

		Task Delete(int id);

		Task<PipelineStatu> Get(int id);

		Task<List<PipelineStatu>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pipeline>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>327c31ddf878d2bfe4ad60177263b264</Hash>
</Codenesium>*/