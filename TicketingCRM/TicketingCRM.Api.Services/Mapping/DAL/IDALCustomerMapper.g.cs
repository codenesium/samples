using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALCustomerMapper
        {
                Customer MapBOToEF(
                        BOCustomer bo);

                BOCustomer MapEFToBO(
                        Customer efCustomer);

                List<BOCustomer> MapEFToBO(
                        List<Customer> records);
        }
}

/*<Codenesium>
    <Hash>4471b170f71a66996b40c91a353e7592</Hash>
</Codenesium>*/