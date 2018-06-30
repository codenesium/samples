using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALTransactionStatusMapper : DALAbstractTransactionStatusMapper, IDALTransactionStatusMapper
        {
                public DALTransactionStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a1d99f7ffdd3294fff38b23bc3c5157d</Hash>
</Codenesium>*/