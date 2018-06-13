using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALCountryMapper: DALAbstractCountryMapper, IDALCountryMapper
        {
                public DALCountryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c0f52974b151a1f81358e4ec8b70b7d1</Hash>
</Codenesium>*/