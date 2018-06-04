using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		Task<Currency> Create(Currency item);

		Task Update(Currency item);

		Task Delete(string currencyCode);

		Task<Currency> Get(string currencyCode);

		Task<List<Currency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<Currency> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>2ead79fedcd1f18c022b47e83fda1625</Hash>
</Codenesium>*/