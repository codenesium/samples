using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRateRepository
	{
		int Create(DateTime currencyRateDate,
		           string fromCurrencyCode,
		           string toCurrencyCode,
		           decimal averageRate,
		           decimal endOfDayRate,
		           DateTime modifiedDate);

		void Update(int currencyRateID, DateTime currencyRateDate,
		            string fromCurrencyCode,
		            string toCurrencyCode,
		            decimal averageRate,
		            decimal endOfDayRate,
		            DateTime modifiedDate);

		void Delete(int currencyRateID);

		void GetById(int currencyRateID, Response response);

		void GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>2cbf86070f3f0bd5b81780627f88f60b</Hash>
</Codenesium>*/