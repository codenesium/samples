using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		int Create(PipelineStepDestinationModel model);

		void Update(int id,
		            PipelineStepDestinationModel model);

		void Delete(int id);

		POCOPipelineStepDestination Get(int id);

		List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9b5066cb5b78a2574bb6e21ea9bd0763</Hash>
</Codenesium>*/