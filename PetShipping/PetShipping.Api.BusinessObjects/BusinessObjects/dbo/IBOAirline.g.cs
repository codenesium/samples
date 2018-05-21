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

		Task<POCOAirline> Get(int id);

		Task<List<POCOAirline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bbbc1a913b7e686cd265475a5f59b539</Hash>
</Codenesium>*/