using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
        {
                public DALCustomerMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>915a20e50d052e8be177fb6826fd02ee</Hash>
</Codenesium>*/