using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
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
    <Hash>102ca2fdd7205ce26cc207149f0942e8</Hash>
</Codenesium>*/