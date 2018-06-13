using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTransactionStatusMapper: DALAbstractTransactionStatusMapper, IDALTransactionStatusMapper
        {
                public DALTransactionStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a4bd8e98f5bb380b0d8f994fbba5b3be</Hash>
</Codenesium>*/