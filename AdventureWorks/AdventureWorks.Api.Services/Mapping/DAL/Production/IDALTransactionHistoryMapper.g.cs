using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>ddf132c51c3ee9cea294ba034bed5cb6</Hash>
</Codenesium>*/