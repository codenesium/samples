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
			ApiHandlerPipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            ApiHandlerPipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		Task<POCOHandlerPipelineStep> Get(int id);

		Task<List<POCOHandlerPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8750fc821529e78a7ea8cfc60526f21a</Hash>
</Codenesium>*/