using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		int Create(int productID,
		           int referenceOrderID,
		           int referenceOrderLineID,
		           DateTime transactionDate,
		           string transactionType,
		           int quantity,
		           decimal actualCost,
		           DateTime modifiedDate);

		void Update(int transactionID, int productID,
		            int referenceOrderID,
		            int referenceOrderLineID,
		            DateTime transactionDate,
		            string transactionType,
		            int quantity,
		            decimal actualCost,
		            DateTime modifiedDate);

		void Delete(int transactionID);

		void GetById(int transactionID, Response response);

		void GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f9d30452326d0212dfa66bdc855aa4dc</Hash>
</Codenesium>*/