using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
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

		void GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8d58a085d2bb5793493e1b086caf43e7</Hash>
</Codenesium>*/