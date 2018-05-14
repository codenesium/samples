using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		POCOTransactionHistory Create(ApiTransactionHistoryModel model);

		void Update(int transactionID,
		            ApiTransactionHistoryModel model);

		void Delete(int transactionID);

		POCOTransactionHistory Get(int transactionID);

		List<POCOTransactionHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOTransactionHistory> GetProductID(int productID);
		List<POCOTransactionHistory> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>ee7372b62f08c050b6420c0c5e8e99fa</Hash>
</Codenesium>*/