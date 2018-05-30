using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IPipelineStepStepRequirementRepository
	{
		Task<DTOPipelineStepStepRequirement> Create(DTOPipelineStepStepRequirement dto);

		Task Update(int id,
		            DTOPipelineStepStepRequirement dto);

		Task Delete(int id);

		Task<DTOPipelineStepStepRequirement> Get(int id);

		Task<List<DTOPipelineStepStepRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>33bd6032aa1f11b8f4c9ed1164a052d8</Hash>
</Codenesium>*/