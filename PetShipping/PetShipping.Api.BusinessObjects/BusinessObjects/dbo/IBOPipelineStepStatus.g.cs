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
		Task<CreateResponse<POCOPipelineStepStatus>> Create(
			ApiPipelineStepStatusModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepStatusModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepStatus Get(int id);

		List<POCOPipelineStepStatus> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ffa46f51bddaa1554a2a7e885605f69a</Hash>
</Codenesium>*/