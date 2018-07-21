using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface IDALSchemaAPersonMapper
        {
                SchemaAPerson MapBOToEF(
                        BOSchemaAPerson bo);

                BOSchemaAPerson MapEFToBO(
                        SchemaAPerson efSchemaAPerson);

                List<BOSchemaAPerson> MapEFToBO(
                        List<SchemaAPerson> records);
        }
}

/*<Codenesium>
    <Hash>db6e7e809a0004ff6ff0ae725f5fcba5</Hash>
</Codenesium>*/