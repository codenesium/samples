using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		Task<DTOCurrency> Create(DTOCurrency dto);

		Task Update(string currencyCode,
		            DTOCurrency dto);

		Task Delete(string currencyCode);

		Task<DTOCurrency> Get(string currencyCode);

		Task<List<DTOCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOCurrency> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>3105d2c997bbce0a05e718c74d07247a</Hash>
</Codenesium>*/