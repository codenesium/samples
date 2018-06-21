using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface ITransactionHistoryRepository
        {
                Task<TransactionHistory> Create(TransactionHistory item);

                Task Update(TransactionHistory item);

                Task Delete(int transactionID);

                Task<TransactionHistory> Get(int transactionID);

                Task<List<TransactionHistory>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<TransactionHistory>> ByProductID(int productID);

                Task<List<TransactionHistory>> ByReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>a3d460e33d76c627dafba0912c9f812d</Hash>
</Codenesium>*/