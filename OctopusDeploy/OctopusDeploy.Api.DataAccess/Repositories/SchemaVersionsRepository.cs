using Codenesium.DataConversionExtensions;
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
    <Hash>6239a33804df854f0f252c07640189a1</Hash>
</Codenesium>*/