using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirlineRepository
	{
		Task<POCOAirline> Create(ApiAirlineModel model);

		Task Update(int id,
		            ApiAirlineModel model);

		Task Delete(int id);

		Task<POCOAirline> Get(int id);

		Task<List<POCOAirline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>318b047127ffc02185833983eaf37636</Hash>
</Codenesium>*/