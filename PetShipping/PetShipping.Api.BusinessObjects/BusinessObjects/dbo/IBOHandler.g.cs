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

		Task<POCOHandler> Get(int id);

		Task<List<POCOHandler>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8c6b80c1ec19ae0666b874924ee6b887</Hash>
</Codenesium>*/