using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirlineRepository
	{
		POCOAirline Create(AirlineModel model);

		void Update(int id,
		            AirlineModel model);

		void Delete(int id);

		POCOAirline Get(int id);

		List<POCOAirline> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>09f3613eb6261c7e966262a1e9340628</Hash>
</Codenesium>*/