using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTransactionStatusMapper : DALAbstractTransactionStatusMapper, IDALTransactionStatusMapper
        {
                public DALTransactionStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6eb37da682521f14e4b12af34f4d9314</Hash>
</Codenesium>*/