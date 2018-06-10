using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    <Hash>f4bf9722689dd2707fc72222f752489e</Hash>
</Codenesium>*/