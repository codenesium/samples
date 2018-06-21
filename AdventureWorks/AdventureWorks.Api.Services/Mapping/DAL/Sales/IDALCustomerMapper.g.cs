using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>69627ff424350da9bdb8508875bfd757</Hash>
</Codenesium>*/