using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		Task<DTOCountryRegion> Create(DTOCountryRegion dto);

		Task Update(string countryRegionCode,
		            DTOCountryRegion dto);

		Task Delete(string countryRegionCode);

		Task<DTOCountryRegion> Get(string countryRegionCode);

		Task<List<DTOCountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOCountryRegion> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>b2b528932671e939e65f9e1ca9d90308</Hash>
</Codenesium>*/