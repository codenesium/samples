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

		Task<POCOClient> Get(int id);

		Task<List<POCOClient>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6912d3be17f4fa32b3589dd3a3ada86f</Hash>
</Codenesium>*/