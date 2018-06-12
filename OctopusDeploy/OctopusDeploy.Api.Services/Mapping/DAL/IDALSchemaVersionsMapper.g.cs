using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALSchemaVersionsMapper
        {
                SchemaVersions MapBOToEF(
                        BOSchemaVersions bo);

                BOSchemaVersions MapEFToBO(
                        SchemaVersions efSchemaVersions);

                List<BOSchemaVersions> MapEFToBO(
                        List<SchemaVersions> records);
        }
}

/*<Codenesium>
    <Hash>2af3081e646b5fdc1f2eb241b15593a0</Hash>
</Codenesium>*/