using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class SchemaVersionsService: AbstractSchemaVersionsService, ISchemaVersionsService
        {
                public SchemaVersionsService(
                        ILogger<SchemaVersionsRepository> logger,
                        ISchemaVersionsRepository schemaVersionsRepository,
                        IApiSchemaVersionsRequestModelValidator schemaVersionsModelValidator,
                        IBOLSchemaVersionsMapper bolschemaVersionsMapper,
                        IDALSchemaVersionsMapper dalschemaVersionsMapper

                        )
                        : base(logger,
                               schemaVersionsRepository,
                               schemaVersionsModelValidator,
                               bolschemaVersionsMapper,
                               dalschemaVersionsMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a5e4e92d99d38dec0389f3b2a9e98d11</Hash>
</Codenesium>*/