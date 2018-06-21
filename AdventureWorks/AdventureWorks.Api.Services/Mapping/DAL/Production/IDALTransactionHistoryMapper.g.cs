using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALTransactionHistoryMapper
        {
                TransactionHistory MapBOToEF(
                        BOTransactionHistory bo);

                BOTransactionHistory MapEFToBO(
                        TransactionHistory efTransactionHistory);

                List<BOTransactionHistory> MapEFToBO(
                        List<TransactionHistory> records);
        }
}

/*<Codenesium>
    <Hash>67b513f7d1c29e5da7ff76760934c953</Hash>
</Codenesium>*/