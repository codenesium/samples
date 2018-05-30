using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRequirementRepository
	{
		Task<DTOCountryRequirement> Create(DTOCountryRequirement dto);

		Task Update(int id,
		            DTOCountryRequirement dto);

		Task Delete(int id);

		Task<DTOCountryRequirement> Get(int id);

		Task<List<DTOCountryRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>91d1cfe718ffc94acbac61ca4f393d3c</Hash>
</Codenesium>*/