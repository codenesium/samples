using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALSaleMapper: DALAbstractSaleMapper, IDALSaleMapper
        {
                public DALSaleMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0652f6d94806f136a05ab9dad776dbe3</Hash>
</Codenesium>*/