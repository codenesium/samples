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
		Task<CreateResponse<int>> Create(
			PipelineStatusModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStatus Get(int id);

		List<POCOPipelineStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bbdf8c9ed55c712be25c52d5071f3af9</Hash>
</Codenesium>*/