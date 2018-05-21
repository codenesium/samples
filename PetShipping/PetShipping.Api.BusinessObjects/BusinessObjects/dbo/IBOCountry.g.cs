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

		Task<POCOCountry> Get(int id);

		Task<List<POCOCountry>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7d4a2d77b3e3d62170305b88e8e67d23</Hash>
</Codenesium>*/