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

		Task<List<Pipeline>> All(int limit = int.MaxValue, int offset = 0);

		Task<PipelineStatus> GetPipelineStatus(int pipelineStatusId);
	}
}

/*<Codenesium>
    <Hash>4afdc3d32cab719c80de2bda2602ba42</Hash>
</Codenesium>*/