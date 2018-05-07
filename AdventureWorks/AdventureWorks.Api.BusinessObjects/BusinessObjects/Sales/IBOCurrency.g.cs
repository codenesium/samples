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
		Task<CreateResponse<string>> Create(
			CurrencyModel model);

		Task<ActionResponse> Update(string currencyCode,
		                            CurrencyModel model);

		Task<ActionResponse> Delete(string currencyCode);

		POCOCurrency Get(string currencyCode);

		List<POCOCurrency> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>56f7506b84b2800801b8a9a2d1acb0a8</Hash>
</Codenesium>*/