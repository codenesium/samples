using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int transactionID);

		POCOTransactionHistoryArchive GetByIdDirect(int transactionID);

		Response GetWhere(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOTransactionHistoryArchive> GetWhereDirect(Expression<Func<EFTransactionHistoryArchive, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>7857519ec7c67ecea6b72258ab271d2c</Hash>
</Codenesium>*/