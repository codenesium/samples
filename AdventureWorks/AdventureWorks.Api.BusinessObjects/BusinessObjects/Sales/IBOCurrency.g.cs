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

		POCOCurrency Get(string currencyCode);

		List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOCurrency GetName(string name);
	}
}

/*<Codenesium>
    <Hash>3d4aeb91cc218bbb2357f22eb4936960</Hash>
</Codenesium>*/