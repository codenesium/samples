using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int currencyRateID);

		POCOCurrencyRate GetByIdDirect(int currencyRateID);

		Response GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOCurrencyRate> GetWhereDirect(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9051deccddce2122b3cd1ca95c665b3d</Hash>
</Codenesium>*/