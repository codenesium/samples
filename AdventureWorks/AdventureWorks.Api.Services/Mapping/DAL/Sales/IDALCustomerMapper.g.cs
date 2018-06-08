using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
    <Hash>24211a5334e6f91c6cfa9a0070fd74cd</Hash>
</Codenesium>*/