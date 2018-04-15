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

		ApiResponse GetById(string countryRegionCode);

		POCOCountryRegion GetByIdDirect(string countryRegionCode);

		ApiResponse GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0a21ba52a3687d3903e39952fb0aff83</Hash>
</Codenesium>*/