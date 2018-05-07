using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		string Create(CurrencyModel model);

		void Update(string currencyCode,
		            CurrencyModel model);

		void Delete(string currencyCode);

		POCOCurrency Get(string currencyCode);

		List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a7e65bbe8894c758ea0f89181840249b</Hash>
</Codenesium>*/