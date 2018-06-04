using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStatusRepository
	{
		Task<PipelineStatus> Create(PipelineStatus item);

		Task Update(PipelineStatus item);

		Task Delete(int id);

		Task<PipelineStatus> Get(int id);

		Task<List<PipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2c46cd4de3c6c441cb03511fd9681c4e</Hash>
</Codenesium>*/