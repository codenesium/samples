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

                Task<List<TransactionHistoryArchive>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<TransactionHistoryArchive>> GetProductID(int productID);
                Task<List<TransactionHistoryArchive>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>dc92a17049bb072d726406d8dd5bbee1</Hash>
</Codenesium>*/