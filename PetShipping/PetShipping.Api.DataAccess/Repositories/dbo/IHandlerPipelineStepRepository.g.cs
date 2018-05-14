using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IHandlerPipelineStepRepository
	{
		POCOHandlerPipelineStep Create(HandlerPipelineStepModel model);

		void Update(int id,
		            HandlerPipelineStepModel model);

		void Delete(int id);

		POCOHandlerPipelineStep Get(int id);

		List<POCOHandlerPipelineStep> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4c9564493dd07d4ede00c4714806cf69</Hash>
</Codenesium>*/