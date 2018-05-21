using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStatusRepository
	{
		Task<POCOPipelineStepStatus> Create(ApiPipelineStepStatusModel model);

		Task Update(int id,
		            ApiPipelineStepStatusModel model);

		Task Delete(int id);

		Task<POCOPipelineStepStatus> Get(int id);

		Task<List<POCOPipelineStepStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7c68ed01b39e5a2671b0ac71ed06b561</Hash>
</Codenesium>*/