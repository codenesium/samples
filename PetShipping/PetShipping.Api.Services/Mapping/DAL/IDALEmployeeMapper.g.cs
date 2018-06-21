using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IDALEmployeeMapper
        {
                Employee MapBOToEF(
                        BOEmployee bo);

                BOEmployee MapEFToBO(
                        Employee efEmployee);

                List<BOEmployee> MapEFToBO(
                        List<Employee> records);
        }
}

/*<Codenesium>
    <Hash>03cb728743b112764dab0218f5f26462</Hash>
</Codenesium>*/