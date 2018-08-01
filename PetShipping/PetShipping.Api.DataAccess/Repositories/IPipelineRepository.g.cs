using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
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
    <Hash>076122e9cebd9d1adedfc1ba375d8e7c</Hash>
</Codenesium>*/