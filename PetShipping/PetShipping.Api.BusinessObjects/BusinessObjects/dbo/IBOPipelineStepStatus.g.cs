using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepStatus
	{
		Task<CreateResponse<int>> Create(
			PipelineStepStatusModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepStatus Get(int id);

		List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3186fe44089497b8b35177e6c911a045</Hash>
</Codenesium>*/