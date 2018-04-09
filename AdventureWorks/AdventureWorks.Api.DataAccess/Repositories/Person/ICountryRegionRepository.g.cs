using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionRepository
	{
		string Create(string name,
		              DateTime modifiedDate);

		void Update(string countryRegionCode, string name,
		            DateTime modifiedDate);

		void Delete(string countryRegionCode);

		Response GetById(string countryRegionCode);

		POCOCountryRegion GetByIdDirect(string countryRegionCode);

		Response GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>101d8b0317e70048c6ac5048fb77ec79</Hash>
</Codenesium>*/