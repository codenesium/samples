using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
	{
		POCOHandlerPipelineStep Create(ApiHandlerPipelineStepModel model);

		void Update(int id,
		            ApiHandlerPipelineStepModel model);

		void Delete(int id);

		POCOHandlerPipelineStep Get(int id);

		List<POCOHandlerPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8830ae359451833579006cb78ef072cb</Hash>
</Codenesium>*/