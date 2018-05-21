using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineRepository
	{
		Task<POCOPipeline> Create(ApiPipelineModel model);

		Task Update(int id,
		            ApiPipelineModel model);

		Task Delete(int id);

		Task<POCOPipeline> Get(int id);

		Task<List<POCOPipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1462c423295e45f7bf8455d90d74ecd3</Hash>
</Codenesium>*/