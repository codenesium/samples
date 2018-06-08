using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>3e9cc0a44c0c6644ab317a504f5c4b50</Hash>
</Codenesium>*/