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
			ApiCountryRequirementModel model);

		Task<ActionResponse> Update(int id,
		                            ApiCountryRequirementModel model);

		Task<ActionResponse> Delete(int id);

		POCOCountryRequirement Get(int id);

		List<POCOCountryRequirement> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>53ff2b2cdf4e086e485a9714b80a6626</Hash>
</Codenesium>*/