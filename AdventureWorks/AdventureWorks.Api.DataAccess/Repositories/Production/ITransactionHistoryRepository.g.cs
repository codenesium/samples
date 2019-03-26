using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ITransactionHistoryRepository
	{
		Task<TransactionHistory> Create(TransactionHistory item);

		Task Update(TransactionHistory item);

		Task Delete(int transactionID);

		Task<TransactionHistory> Get(int transactionID);

		Task<List<TransactionHistory>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<TransactionHistory>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistory>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);

		Task<Product> ProductByProductID(int productID);
	}
}

/*<Codenesium>
    <Hash>c9204fb2a83111b870618d1f9e1e19c4</Hash>
</Codenesium>*/