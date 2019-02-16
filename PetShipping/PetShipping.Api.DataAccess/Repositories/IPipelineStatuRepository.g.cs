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

		Task<List<PipelineStatu>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Pipeline>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>45390a666d0528ebb8a1894a48fc68d4</Hash>
</Codenesium>*/