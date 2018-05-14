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
		Task<CreateResponse<POCOPipelineStep>> Create(
			PipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStep Get(int id);

		List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3f7a3f870c38073f60d8169962662fdd</Hash>
</Codenesium>*/