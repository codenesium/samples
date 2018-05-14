using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOHandlerPipelineStep
	{
		Task<CreateResponse<POCOHandlerPipelineStep>> Create(
			HandlerPipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            HandlerPipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		POCOHandlerPipelineStep Get(int id);

		List<POCOHandlerPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>525d49f9571ba0b2b8ece3432460c00d</Hash>
</Codenesium>*/