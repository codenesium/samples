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

		ApiResponse GetById(string currencyCode);

		POCOCurrency GetByIdDirect(string currencyCode);

		ApiResponse GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3638952486a005cb5417a8ed8fff1aac</Hash>
</Codenesium>*/