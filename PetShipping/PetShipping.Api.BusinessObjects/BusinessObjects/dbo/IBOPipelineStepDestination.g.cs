using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOPipelineStepDestination
	{
		Task<CreateResponse<POCOPipelineStepDestination>> Create(
			ApiPipelineStepDestinationModel model);

		Task<ActionResponse> Update(int id,
		                            ApiPipelineStepDestinationModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepDestination Get(int id);

		List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>c0e9dd6f9b446525f5ccffb0b25848a6</Hash>
</Codenesium>*/