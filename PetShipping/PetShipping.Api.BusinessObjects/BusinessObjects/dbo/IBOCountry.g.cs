using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOCountry
	{
		Task<CreateResponse<POCOCountry>> Create(
			ApiCountryModel model);

		Task<ActionResponse> Update(int id,
		                            ApiCountryModel model);

		Task<ActionResponse> Delete(int id);

		POCOCountry Get(int id);

		List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8f909fc87b57989ef76d7de2e64082e7</Hash>
</Codenesium>*/