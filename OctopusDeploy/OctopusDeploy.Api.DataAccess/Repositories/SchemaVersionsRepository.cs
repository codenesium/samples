using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class SchemaVersionsRepository : AbstractSchemaVersionsRepository, ISchemaVersionsRepository
        {
                public SchemaVersionsRepository(
                        ILogger<SchemaVersionsRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>918f894c28b18c1f55f513b785f30eb2</Hash>
</Codenesium>*/