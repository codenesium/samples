using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class SchemaVersionsService : AbstractSchemaVersionsService, ISchemaVersionsService
        {
                public SchemaVersionsService(
                        ILogger<ISchemaVersionsRepository> logger,
                        ISchemaVersionsRepository schemaVersionsRepository,
                        IApiSchemaVersionsRequestModelValidator schemaVersionsModelValidator,
                        IBOLSchemaVersionsMapper bolschemaVersionsMapper,
                        IDALSchemaVersionsMapper dalschemaVersionsMapper
                        )
                        : base(logger,
                               schemaVersionsRepository,
                               schemaVersionsModelValidator,
                               bolschemaVersionsMapper,
                               dalschemaVersionsMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>092601d377cec7951df09d662a936980</Hash>
</Codenesium>*/