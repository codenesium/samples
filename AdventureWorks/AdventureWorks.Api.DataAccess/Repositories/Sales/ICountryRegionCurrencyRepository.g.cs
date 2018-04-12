using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICountryRegionCurrencyRepository
	{
		string Create(
			string currencyCode,
			DateTime modifiedDate);

		void Update(string countryRegionCode,
		            string currencyCode,
		            DateTime modifiedDate);

		void Delete(string countryRegionCode);

		Response GetById(string countryRegionCode);

		POCOCountryRegionCurrency GetByIdDirect(string countryRegionCode);

		Response GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCountryRegionCurrency> GetWhereDirect(Expression<Func<EFCountryRegionCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>25d570760ee39ec56bd4b19be928bb35</Hash>
</Codenesium>*/