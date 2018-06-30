using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class SchemaVersionsRepository : AbstractSchemaVersionsRepository, ISchemaVersionsRepository
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
    <Hash>946da42a421c5af3d6949fb57bce3a5e</Hash>
</Codenesium>*/