using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public interface IBOAirline
	{
		Task<CreateResponse<POCOAirline>> Create(
			ApiAirlineModel model);

		Task<ActionResponse> Update(int id,
		                            ApiAirlineModel model);

		Task<ActionResponse> Delete(int id);

		POCOAirline Get(int id);

		List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>dcbe925e81cbf479a2a248c4fe7d279b</Hash>
</Codenesium>*/