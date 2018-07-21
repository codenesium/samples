using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALPersonMapper
        {
                Person MapBOToEF(
                        BOPerson bo);

                BOPerson MapEFToBO(
                        Person efPerson);

                List<BOPerson> MapEFToBO(
                        List<Person> records);
        }
}

/*<Codenesium>
    <Hash>51b45c0142072e6a9d8f5584aa42cdfc</Hash>
</Codenesium>*/