using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTransactionMapper: DALAbstractTransactionMapper, IDALTransactionMapper
        {
                public DALTransactionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3185c5632d8c25e88df7a190d8fa6979</Hash>
</Codenesium>*/