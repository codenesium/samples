using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		string Create(
			string name,
			DateTime modifiedDate);

		void Update(string currencyCode,
		            string name,
		            DateTime modifiedDate);

		void Delete(string currencyCode);

		Response GetById(string currencyCode);

		POCOCurrency GetByIdDirect(string currencyCode);

		Response GetWhere(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOCurrency> GetWhereDirect(Expression<Func<EFCurrency, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>bc2f67fefc2fb02acb68919f27b9a32d</Hash>
</Codenesium>*/