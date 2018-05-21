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

		Task<POCOPipelineStepDestination> Get(int id);

		Task<List<POCOPipelineStepDestination>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bba6190648305eb984e6db94b3b0719d</Hash>
</Codenesium>*/