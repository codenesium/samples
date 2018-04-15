using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRateRepository
	{
		int Create(CurrencyRateModel model);

		void Update(int currencyRateID,
		            CurrencyRateModel model);

		void Delete(int currencyRateID);

		ApiResponse GetById(int currencyRateID);

		POCOCurrencyRate GetByIdDirect(int currencyRateID);

		ApiResponse GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCurrencyRate> GetWhereDirect(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a2b8e60ed0157c41fc5e7b41341d425f</Hash>
</Codenesium>*/