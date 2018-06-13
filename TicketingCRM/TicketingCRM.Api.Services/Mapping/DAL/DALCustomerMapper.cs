using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALCustomerMapper: DALAbstractCustomerMapper, IDALCustomerMapper
        {
                public DALCustomerMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>58eca2de3dd6ebea8e28342ab8eadff1</Hash>
</Codenesium>*/