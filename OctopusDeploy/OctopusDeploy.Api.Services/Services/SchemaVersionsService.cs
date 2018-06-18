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
                               dalschemaVersionsMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>20d1fa999c62c040feb62eec56fb82d8</Hash>
</Codenesium>*/