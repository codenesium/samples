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
			ApiPipelineStepModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStep Get(int id);

		List<POCOPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a77453766a3aad23a54e3784c5dbbeba</Hash>
</Codenesium>*/