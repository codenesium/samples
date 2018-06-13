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

                Task<List<TransactionHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<TransactionHistory>> GetProductID(int productID);
                Task<List<TransactionHistory>> GetReferenceOrderIDReferenceOrderLineID(int referenceOrderID, int referenceOrderLineID);
        }
}

/*<Codenesium>
    <Hash>d42eec751700761437c97767d29966e0</Hash>
</Codenesium>*/