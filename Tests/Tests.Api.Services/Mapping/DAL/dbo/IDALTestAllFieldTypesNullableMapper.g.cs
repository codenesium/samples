using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALTestAllFieldTypesNullableMapper
        {
                TestAllFieldTypesNullable MapBOToEF(
                        BOTestAllFieldTypesNullable bo);

                BOTestAllFieldTypesNullable MapEFToBO(
                        TestAllFieldTypesNullable efTestAllFieldTypesNullable);

                List<BOTestAllFieldTypesNullable> MapEFToBO(
                        List<TestAllFieldTypesNullable> records);
        }
}

/*<Codenesium>
    <Hash>246d1ff8f45cc1eeb7f23e93e86b1332</Hash>
</Codenesium>*/