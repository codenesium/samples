using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		string Create(CountryRegionModel model);

		void Update(string countryRegionCode,
		            CountryRegionModel model);

		void Delete(string countryRegionCode);

		POCOCountryRegion Get(string countryRegionCode);

		List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>46ca3030e0380aec70b424f73be9e437</Hash>
</Codenesium>*/