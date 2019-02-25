using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public partial interface IPipelineStatusRepository
	{
		Task<PipelineStatus> Create(PipelineStatus item);

		Task Update(PipelineStatus item);

		Task Delete(int id);

		Task<PipelineStatus> Get(int id);

		Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<Pipeline>> PipelinesByPipelineStatusId(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>93a0928f8c15bdf3772b7a1f944a8345</Hash>
</Codenesium>*/