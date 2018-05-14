using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		POCOPipelineStepStepRequirement Create(PipelineStepStepRequirementModel model);

		void Update(int id,
		            PipelineStepStepRequirementModel model);

		void Delete(int id);

		POCOPipelineStepStepRequirement Get(int id);

		List<POCOPipelineStepStepRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fea2a272dceb845acef1aba1bf64726f</Hash>
</Codenesium>*/