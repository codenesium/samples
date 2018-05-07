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

		POCOCurrencyRate Get(int currencyRateID);

		List<POCOCurrencyRate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b3aa0eb29af180dabc7e0cb6e07e050f</Hash>
</Codenesium>*/