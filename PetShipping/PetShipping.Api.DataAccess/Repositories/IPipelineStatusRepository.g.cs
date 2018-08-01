using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		Task<PipelineStatus> Create(PipelineStatus item);

		Task Update(PipelineStatus item);

		Task Delete(int id);

		Task<PipelineStatus> Get(int id);

		Task<List<PipelineStatus>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<Pipeline>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d1e312735725e293d52dde0611797126</Hash>
</Codenesium>*/