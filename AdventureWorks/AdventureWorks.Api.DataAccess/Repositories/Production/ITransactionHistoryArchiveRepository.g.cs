using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		Task<TransactionHistoryArchive> Create(TransactionHistoryArchive item);

		Task Update(TransactionHistoryArchive item);

		Task Delete(int transactionID);

		Task<TransactionHistoryArchive> Get(int transactionID);

		Task<List<TransactionHistoryArchive>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistoryArchive>> ByProductID(int productID);

		Task<List<TransactionHistoryArchive>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>9e0093fb46da5900ec397dbe660d4983</Hash>
</Codenesium>*/