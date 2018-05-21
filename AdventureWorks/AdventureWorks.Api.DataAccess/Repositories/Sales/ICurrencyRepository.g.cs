using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		Task<POCOCurrency> Create(ApiCurrencyModel model);

		Task Update(string currencyCode,
		            ApiCurrencyModel model);

		Task Delete(string currencyCode);

		Task<POCOCurrency> Get(string currencyCode);

		Task<List<POCOCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCurrency> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>98991f005aca5fcf044f28eb33e4eb15</Hash>
</Codenesium>*/