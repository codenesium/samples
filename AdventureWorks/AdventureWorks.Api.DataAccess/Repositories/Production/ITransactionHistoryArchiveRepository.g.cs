using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface ITransactionHistoryArchiveRepository
	{
		Task<TransactionHistoryArchive> Create(TransactionHistoryArchive item);

		Task Update(TransactionHistoryArchive item);

		Task Delete(int transactionID);

		Task<TransactionHistoryArchive> Get(int transactionID);

		Task<List<TransactionHistoryArchive>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<TransactionHistoryArchive>> GetProductID(int productID);
		Task<List<TransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID,int referenceOrderLineID);
	}
}

/*<Codenesium>
    <Hash>e97365b391e36b16b30691fe9722f35a</Hash>
</Codenesium>*/