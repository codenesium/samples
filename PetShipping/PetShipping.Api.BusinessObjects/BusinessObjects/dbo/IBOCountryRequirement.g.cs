using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOCountryRequirement
	{
		Task<CreateResponse<POCOCountryRequirement>> Create(
			CountryRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            CountryRequirementModel model);

		Task<ActionResponse> Delete(int id);

		POCOCountryRequirement Get(int id);

		List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6934acacb9638276b1eeda2447013dd7</Hash>
</Codenesium>*/