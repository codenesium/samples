using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>a60f4523935fde7b7454fae470b7a5c3</Hash>
</Codenesium>*/