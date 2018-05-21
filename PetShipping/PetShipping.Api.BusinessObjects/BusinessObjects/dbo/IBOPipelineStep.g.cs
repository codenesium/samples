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

		Task<POCOPipelineStep> Get(int id);

		Task<List<POCOPipelineStep>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ea6a48ff014756fa332972523ef2f4b9</Hash>
</Codenesium>*/