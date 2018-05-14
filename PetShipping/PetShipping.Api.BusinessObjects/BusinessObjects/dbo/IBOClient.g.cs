using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOClient
	{
		Task<CreateResponse<POCOClient>> Create(
			ApiClientModel model);

		Task<ActionResponse> Update(int id,
		                            ApiClientModel model);

		Task<ActionResponse> Delete(int id);

		POCOClient Get(int id);

		List<POCOClient> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>adf2c742372a1dc4aa24c267dcccabaf</Hash>
</Codenesium>*/