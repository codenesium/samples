using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStatus
	{
		Task<CreateResponse<POCOPipelineStatus>> Create(
			ApiPipelineStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStatusModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOPipelineStatus> Get(int id);

		Task<List<POCOPipelineStatus>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9062a20c51f77ca523066d58d1bb27f0</Hash>
</Codenesium>*/