using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>b8c5d2ffe8038eded85288d4b63e4636</Hash>
</Codenesium>*/