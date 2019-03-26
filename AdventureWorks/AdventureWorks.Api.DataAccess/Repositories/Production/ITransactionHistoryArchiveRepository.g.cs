using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface ITransactionHistoryArchiveRepository
	{
		Task<TransactionHistoryArchive> Create(TransactionHistoryArchive item);

		Task Update(TransactionHistoryArchive item);

		Task Delete(int transactionID);

		Task<TransactionHistoryArchive> Get(int transactionID);

		Task<List<TransactionHistoryArchive>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<TransactionHistoryArchive>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistoryArchive>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>8f64e5b499a2c524bb091939e0545acc</Hash>
</Codenesium>*/