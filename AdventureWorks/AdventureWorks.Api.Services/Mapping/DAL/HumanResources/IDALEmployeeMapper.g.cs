using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
    <Hash>4b8d52ad0b9ac8805a3c1c4e5625f5cb</Hash>
</Codenesium>*/