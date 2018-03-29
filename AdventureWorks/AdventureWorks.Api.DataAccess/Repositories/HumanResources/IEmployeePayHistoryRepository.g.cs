using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IEmployeePayHistoryRepository
	{
		int Create(DateTime rateChangeDate,
		           decimal rate,
		           int payFrequency,
		           DateTime modifiedDate);

		void Update(int businessEntityID, DateTime rateChangeDate,
		            decimal rate,
		            int payFrequency,
		            DateTime modifiedDate);

		void Delete(int businessEntityID);

		void GetById(int businessEntityID, Response response);

		void GetWhere(Expression<Func<EFEmployeePayHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>d52210271704f9d896324a827b73c9ce</Hash>
</Codenesium>*/