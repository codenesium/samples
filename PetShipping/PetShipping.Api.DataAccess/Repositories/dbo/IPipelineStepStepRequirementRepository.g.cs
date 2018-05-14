using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		POCOPipelineStepStepRequirement Create(ApiPipelineStepStepRequirementModel model);

		void Update(int id,
		            ApiPipelineStepStepRequirementModel model);

		void Delete(int id);

		POCOPipelineStepStepRequirement Get(int id);

		List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>18653c40767d1e19276e0b922686ac66</Hash>
</Codenesium>*/