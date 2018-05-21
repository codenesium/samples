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

		Task<POCOCountryRequirement> Get(int id);

		Task<List<POCOCountryRequirement>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>deb4b1b21144c0cf44ac257d75310542</Hash>
</Codenesium>*/