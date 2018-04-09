using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int transactionID);

		POCOTransactionHistory GetByIdDirect(int transactionID);

		Response GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>52d538c9d642c3ecd53c20d62b140764</Hash>
</Codenesium>*/