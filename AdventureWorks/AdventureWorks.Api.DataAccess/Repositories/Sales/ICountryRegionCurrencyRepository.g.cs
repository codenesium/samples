using System;
using System.Linq.Expressions;
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

		void GetById(string countryRegionCode, Response response);

		void GetWhere(Expression<Func<EFCountryRegionCurrency, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6e42d4a4a5db6daea34c3499f696b589</Hash>
</Codenesium>*/