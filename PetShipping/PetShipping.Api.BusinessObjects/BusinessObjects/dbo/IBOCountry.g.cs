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
			CountryModel model);

		Task<ActionResponse> Update(int id,
		                            CountryModel model);

		Task<ActionResponse> Delete(int id);

		POCOCountry Get(int id);

		List<POCOCountry> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bb7a44097d69fac2f3d00035facbdbfe</Hash>
</Codenesium>*/