using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineRepository
	{
		Task<Pipeline> Create(Pipeline item);

		Task Update(Pipeline item);

		Task Delete(int id);

		Task<Pipeline> Get(int id);

		Task<List<Pipeline>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<PipelineStatu> PipelineStatuByPipelineStatusId(int pipelineStatusId);
	}
}

/*<Codenesium>
    <Hash>d409df84add7a1104ebadd8730e46ed2</Hash>
</Codenesium>*/