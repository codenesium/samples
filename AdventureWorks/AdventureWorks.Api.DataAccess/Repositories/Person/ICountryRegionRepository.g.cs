using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		POCOCountryRegion Create(ApiCountryRegionModel model);

		void Update(string countryRegionCode,
		            ApiCountryRegionModel model);

		void Delete(string countryRegionCode);

		POCOCountryRegion Get(string countryRegionCode);

		List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCountryRegion GetName(string name);
	}
}

/*<Codenesium>
    <Hash>99f10cc36b825cab63d2a01f3f1d8b3a</Hash>
</Codenesium>*/