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
    <Hash>ba6cd74f2a60d760cbd6676c22b7bd2d</Hash>
</Codenesium>*/