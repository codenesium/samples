using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALCountryMapper : DALAbstractCountryMapper, IDALCountryMapper
        {
                public DALCountryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ea22d7218bd9d8edc07d061356db8371</Hash>
</Codenesium>*/