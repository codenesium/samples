using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRequirementRepository
	{
		Task<POCOCountryRequirement> Create(ApiCountryRequirementModel model);

		Task Update(int id,
		            ApiCountryRequirementModel model);

		Task Delete(int id);

		Task<POCOCountryRequirement> Get(int id);

		Task<List<POCOCountryRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8b74b4cdc1c1c8948162e192e78f8f9d</Hash>
</Codenesium>*/