using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>38aa6fd75c0e9786d82cc93da7e70cab</Hash>
</Codenesium>*/