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
			PipelineStepDestinationModel model);

		Task<ActionResponse> Update(int id,
		                            PipelineStepDestinationModel model);

		Task<ActionResponse> Delete(int id);

		POCOPipelineStepDestination Get(int id);

		List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>de96b14bee44c3fe8e2171020db8a67e</Hash>
</Codenesium>*/