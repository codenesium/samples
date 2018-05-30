using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface IAirlineRepository
	{
		Task<DTOAirline> Create(DTOAirline dto);

		Task Update(int id,
		            DTOAirline dto);

		Task Delete(int id);

		Task<DTOAirline> Get(int id);

		Task<List<DTOAirline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d09545156199448a3e73ec8121f1ac2d</Hash>
</Codenesium>*/