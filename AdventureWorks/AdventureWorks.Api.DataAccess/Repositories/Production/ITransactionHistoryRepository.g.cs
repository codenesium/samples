using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		int Create(
			int productID,
			int referenceOrderID,
			int referenceOrderLineID,
			DateTime transactionDate,
			string transactionType,
			int quantity,
			decimal actualCost,
			DateTime modifiedDate);

		void Update(int transactionID,
		            int productID,
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

		Response GetWhere(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistory> GetWhereDirect(Expression<Func<EFTransactionHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>38242ccbafa4b2123111fbc1e314369d</Hash>
</Codenesium>*/