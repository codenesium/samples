using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTicketStatusMapper: DALAbstractTicketStatusMapper, IDALTicketStatusMapper
        {
                public DALTicketStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2cbce5ad3efdcc1b9995bcca7cda48bd</Hash>
</Codenesium>*/