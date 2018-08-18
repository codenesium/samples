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

		Task<List<TransactionHistory>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistory>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistory>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>37fb49d2bd79a2b5e4f2af59ec50932b</Hash>
</Codenesium>*/