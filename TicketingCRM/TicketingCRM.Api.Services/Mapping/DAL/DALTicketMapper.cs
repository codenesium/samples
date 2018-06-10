using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTicketMapper: DALAbstractTicketMapper, IDALTicketMapper
        {
                public DALTicketMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa5705b30f55d6dfa02faad0b10c63c7</Hash>
</Codenesium>*/