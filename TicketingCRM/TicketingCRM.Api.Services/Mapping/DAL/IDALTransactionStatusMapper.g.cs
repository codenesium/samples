using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    <Hash>8d6f95557d23994fd51cc4b8903baa3a</Hash>
</Codenesium>*/