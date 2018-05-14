using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		POCOCurrency Create(ApiCurrencyModel model);

		void Update(string currencyCode,
		            ApiCurrencyModel model);

		void Delete(string currencyCode);

		POCOCurrency Get(string currencyCode);

		List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCurrency GetName(string name);
	}
}

/*<Codenesium>
    <Hash>a75c4ef678ba49378a1f5fdf53c90312</Hash>
</Codenesium>*/