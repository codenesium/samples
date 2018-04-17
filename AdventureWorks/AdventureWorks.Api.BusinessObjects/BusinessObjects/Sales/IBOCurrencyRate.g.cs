using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOCurrencyRate
	{
		Task<CreateResponse<int>> Create(
			CurrencyRateModel model);

		Task<ActionResponse> Update(int currencyRateID,
		                            CurrencyRateModel model);

		Task<ActionResponse> Delete(int currencyRateID);

		ApiResponse GetById(int currencyRateID);

		POCOCurrencyRate GetByIdDirect(int currencyRateID);

		ApiResponse GetWhere(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCurrencyRate> GetWhereDirect(Expression<Func<EFCurrencyRate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b593edee63e09013512cc794c1606332</Hash>
</Codenesium>*/