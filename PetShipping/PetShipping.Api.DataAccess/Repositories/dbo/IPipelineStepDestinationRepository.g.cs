using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepDestinationRepository
	{
		POCOPipelineStepDestination Create(ApiPipelineStepDestinationModel model);

		void Update(int id,
		            ApiPipelineStepDestinationModel model);

		void Delete(int id);

		POCOPipelineStepDestination Get(int id);

		List<POCOPipelineStepDestination> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5aa976875cc50b1d298eb5e6a0109c46</Hash>
</Codenesium>*/