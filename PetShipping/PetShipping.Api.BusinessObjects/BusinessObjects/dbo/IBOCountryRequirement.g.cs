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
		Task<CreateResponse<int>> Create(
			CountryRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            CountryRequirementModel model);

		Task<ActionResponse> Delete(int id);

		POCOCountryRequirement Get(int id);

		List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>45580cc5c7448042645e7a22ae854f78</Hash>
</Codenesium>*/