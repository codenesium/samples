using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		int Create(PipelineStepStepRequirementModel model);

		void Update(int id,
		            PipelineStepStepRequirementModel model);

		void Delete(int id);

		POCOPipelineStepStepRequirement Get(int id);

		List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>27a6840cae29bee63f04596327d7c712</Hash>
</Codenesium>*/