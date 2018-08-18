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

		Task<List<TransactionHistoryArchive>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistoryArchive>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistoryArchive>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>881b7b2c35d806f75f298773d1a21608</Hash>
</Codenesium>*/