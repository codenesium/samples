using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		POCOPipelineStepDestination Create(PipelineStepDestinationModel model);

		void Update(int id,
		            PipelineStepDestinationModel model);

		void Delete(int id);

		POCOPipelineStepDestination Get(int id);

		List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>491b321b09f896aa91ee53fd6e6abb27</Hash>
</Codenesium>*/