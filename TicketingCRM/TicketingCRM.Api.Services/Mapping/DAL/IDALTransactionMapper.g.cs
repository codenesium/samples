using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALTransactionMapper
        {
                Transaction MapBOToEF(
                        BOTransaction bo);

                BOTransaction MapEFToBO(
                        Transaction efTransaction);

                List<BOTransaction> MapEFToBO(
                        List<Transaction> records);
        }
}

/*<Codenesium>
    <Hash>f34cbc4ae9ed51142b7985959cf75014</Hash>
</Codenesium>*/