using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALEventMapper : DALAbstractEventMapper, IDALEventMapper
        {
                public DALEventMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>606b035681ca9e062c05cdf303eec993</Hash>
</Codenesium>*/