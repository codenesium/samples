using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOHandler
	{
		Task<CreateResponse<POCOHandler>> Create(
			ApiHandlerModel model);

		Task<ActionResponse> Update(int id,
		                            ApiHandlerModel model);

		Task<ActionResponse> Delete(int id);

		POCOHandler Get(int id);

		List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3f8ef7303cb18dcbb32dcc6febfa3d26</Hash>
</Codenesium>*/