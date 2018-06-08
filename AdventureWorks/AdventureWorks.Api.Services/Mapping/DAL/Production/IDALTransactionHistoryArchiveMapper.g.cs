using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>b568d4fe5ca97a2402366c3831ff0613</Hash>
</Codenesium>*/