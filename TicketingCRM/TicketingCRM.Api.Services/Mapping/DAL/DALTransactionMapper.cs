using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTransactionMapper : DALAbstractTransactionMapper, IDALTransactionMapper
        {
                public DALTransactionMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>02f335ab0c42ddb1f605fdd67ab62ec3</Hash>
</Codenesium>*/