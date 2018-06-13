using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALTransactionStatusMapper
        {
                TransactionStatus MapBOToEF(
                        BOTransactionStatus bo);

                BOTransactionStatus MapEFToBO(
                        TransactionStatus efTransactionStatus);

                List<BOTransactionStatus> MapEFToBO(
                        List<TransactionStatus> records);
        }
}

/*<Codenesium>
    <Hash>72834bacf685ad5dc6c86d1531f2f8b7</Hash>
</Codenesium>*/