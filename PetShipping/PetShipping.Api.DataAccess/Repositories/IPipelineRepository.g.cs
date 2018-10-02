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

		Task<PipelineStatu> GetPipelineStatu(int pipelineStatusId);
	}
}

/*<Codenesium>
    <Hash>35c7d8cb99c67b7bcb490f1d0a90e859</Hash>
</Codenesium>*/