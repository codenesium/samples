using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class SchemaAPersonRepository : AbstractSchemaAPersonRepository, ISchemaAPersonRepository
        {
                public SchemaAPersonRepository(
                        ILogger<SchemaAPersonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1105525747dd72cce981ae7652493a1c</Hash>
</Codenesium>*/