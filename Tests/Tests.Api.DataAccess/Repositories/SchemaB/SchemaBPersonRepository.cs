using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class SchemaBPersonRepository : AbstractSchemaBPersonRepository, ISchemaBPersonRepository
        {
                public SchemaBPersonRepository(
                        ILogger<SchemaBPersonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>25fbcfabb6d390188d7716a8afd3346e</Hash>
</Codenesium>*/