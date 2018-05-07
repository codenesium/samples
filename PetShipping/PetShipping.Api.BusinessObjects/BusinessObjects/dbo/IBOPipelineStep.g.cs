using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStep
	{
		Task<CreateResponse<int>> Create(
			PipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStep Get(int id);

		List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c96a9c0f653e4e16afa94643aed442a3</Hash>
</Codenesium>*/