using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALTestAllFieldTypeMapper
        {
                TestAllFieldType MapBOToEF(
                        BOTestAllFieldType bo);

                BOTestAllFieldType MapEFToBO(
                        TestAllFieldType efTestAllFieldType);

                List<BOTestAllFieldType> MapEFToBO(
                        List<TestAllFieldType> records);
        }
}

/*<Codenesium>
    <Hash>715174af435e2ca32dd2d4aa85fe5069</Hash>
</Codenesium>*/