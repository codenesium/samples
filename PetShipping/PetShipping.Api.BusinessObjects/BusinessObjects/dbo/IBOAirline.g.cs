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
		Task<CreateResponse<int>> Create(
			AirlineModel model);

		Task<ActionResponse> Update(int id,
		                            AirlineModel model);

		Task<ActionResponse> Delete(int id);

		POCOAirline Get(int id);

		List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3664a8a20a461e83f32229fddb5f6969</Hash>
</Codenesium>*/