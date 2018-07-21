using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public partial class SchemaAPersonService : AbstractSchemaAPersonService, ISchemaAPersonService
        {
                public SchemaAPersonService(
                        ILogger<ISchemaAPersonRepository> logger,
                        ISchemaAPersonRepository schemaAPersonRepository,
                        IApiSchemaAPersonRequestModelValidator schemaAPersonModelValidator,
                        IBOLSchemaAPersonMapper bolschemaAPersonMapper,
                        IDALSchemaAPersonMapper dalschemaAPersonMapper
                        )
                        : base(logger,
                               schemaAPersonRepository,
                               schemaAPersonModelValidator,
                               bolschemaAPersonMapper,
                               dalschemaAPersonMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5488bcf5ec2f67c6aa7550ed265ebea8</Hash>
</Codenesium>*/