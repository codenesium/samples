using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALTransactionHistoryArchiveMapper
        {
                TransactionHistoryArchive MapBOToEF(
                        BOTransactionHistoryArchive bo);

                BOTransactionHistoryArchive MapEFToBO(
                        TransactionHistoryArchive efTransactionHistoryArchive);

                List<BOTransactionHistoryArchive> MapEFToBO(
                        List<TransactionHistoryArchive> records);
        }
}

/*<Codenesium>
    <Hash>9257152e583ddaeebb63167a1dbee606</Hash>
</Codenesium>*/