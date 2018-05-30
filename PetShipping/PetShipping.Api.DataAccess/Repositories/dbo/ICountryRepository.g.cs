using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public interface ICountryRepository
	{
		Task<DTOCountry> Create(DTOCountry dto);

		Task Update(int id,
		            DTOCountry dto);

		Task Delete(int id);

		Task<DTOCountry> Get(int id);

		Task<List<DTOCountry>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>14397f2a1f9cf64bb02d3983614a2ddf</Hash>
</Codenesium>*/