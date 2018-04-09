using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		string Create(string currencyCode,
		              DateTime modifiedDate);

		void Update(string countryRegionCode, string currencyCode,
		            DateTime modifiedDate);

		void Delete(string countryRegionCode);

		Response GetById(string countryRegionCode);

		POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode);

		Response GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1865f1b0ad64b95926a9bab645c9d3f4</Hash>
</Codenesium>*/