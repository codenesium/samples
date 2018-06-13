using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALEventMapper: DALAbstractEventMapper, IDALEventMapper
        {
                public DALEventMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0745610ff356ce3a9cb98d4b271c190f</Hash>
</Codenesium>*/