using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryRepository
	{
		Task<TransactionHistory> Create(TransactionHistory item);

		Task Update(TransactionHistory item);

		Task Delete(int transactionID);

		Task<TransactionHistory> Get(int transactionID);

		Task<List<TransactionHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<TransactionHistory>> GetProductID(int productID);
		Task<List<TransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>38129bb2c89fd685e422f2d4cf0e2302</Hash>
</Codenesium>*/