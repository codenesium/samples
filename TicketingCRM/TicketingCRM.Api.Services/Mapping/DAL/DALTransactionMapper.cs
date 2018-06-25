using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALTransactionMapper : DALAbstractTransactionMapper, IDALTransactionMapper
        {
                public DALTransactionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>365ba4d609689ee7e340cdf322d1b805</Hash>
</Codenesium>*/