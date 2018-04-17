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

		ApiResponse GetById(string currencyCode);

		POCOCurrency GetByIdDirect(string currencyCode);

		ApiResponse GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>56de89800598086648d80cc94138e4bb</Hash>
</Codenesium>*/