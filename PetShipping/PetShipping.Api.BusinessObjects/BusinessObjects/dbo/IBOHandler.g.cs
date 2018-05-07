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
		Task<CreateResponse<int>> Create(
			HandlerModel model);

		Task<ActionResponse> Update(int id,
		                            HandlerModel model);

		Task<ActionResponse> Delete(int id);

		POCOHandler Get(int id);

		List<POCOHandler> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>09e8884193330e9a9f6612f7d9c847dc</Hash>
</Codenesium>*/