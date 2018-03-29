using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ICurrencyRepository
	{
		string Create(string name,
		              DateTime modifiedDate);

		void Update(string currencyCode, string name,
		            DateTime modifiedDate);

		void Delete(string currencyCode);

		void GetById(string currencyCode, Response response);

		void GetWhere(Expression<Func<EFCurrency, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>860866e3d629f89e0bc8983f6ecffaf5</Hash>
</Codenesium>*/