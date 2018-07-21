using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALSelfReferenceMapper
        {
                SelfReference MapBOToEF(
                        BOSelfReference bo);

                BOSelfReference MapEFToBO(
                        SelfReference efSelfReference);

                List<BOSelfReference> MapEFToBO(
                        List<SelfReference> records);
        }
}

/*<Codenesium>
    <Hash>15b9347424c84edf64fd83b948f0ec94</Hash>
</Codenesium>*/