using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>55a5422391fa624fb10fd21eb5968694</Hash>
</Codenesium>*/