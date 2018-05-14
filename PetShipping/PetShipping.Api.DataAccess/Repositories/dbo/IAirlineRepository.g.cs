using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirlineRepository
	{
		POCOAirline Create(ApiAirlineModel model);

		void Update(int id,
		            ApiAirlineModel model);

		void Delete(int id);

		POCOAirline Get(int id);

		List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>17469a8237e7d632493d292a1ad628f3</Hash>
</Codenesium>*/