using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCurrency
	{
		Task<CreateResponse<POCOCurrency>> Create(
			ApiCurrencyModel model);

		Task<ActionResponse> Update(string currencyCode,
		                            ApiCurrencyModel model);

		Task<ActionResponse> Delete(string currencyCode);

		Task<POCOCurrency> Get(string currencyCode);

		Task<List<POCOCurrency>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOCurrency> GetName(string name);
	}
}

/*<Codenesium>
    <Hash>1d09ac2410bb5a01fda82dc7c226526f</Hash>
</Codenesium>*/