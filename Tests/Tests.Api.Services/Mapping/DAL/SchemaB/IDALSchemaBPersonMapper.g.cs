using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALSchemaBPersonMapper
        {
                SchemaBPerson MapBOToEF(
                        BOSchemaBPerson bo);

                BOSchemaBPerson MapEFToBO(
                        SchemaBPerson efSchemaBPerson);

                List<BOSchemaBPerson> MapEFToBO(
                        List<SchemaBPerson> records);
        }
}

/*<Codenesium>
    <Hash>17cacd8b873bf118d1bdc41787a60291</Hash>
</Codenesium>*/