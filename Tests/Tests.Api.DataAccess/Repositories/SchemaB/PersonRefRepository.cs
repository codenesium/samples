using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class PersonRefRepository : AbstractPersonRefRepository, IPersonRefRepository
        {
                public PersonRefRepository(
                        ILogger<PersonRefRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>92738abc7a3c9dc9d41da1bf2f9654aa</Hash>
</Codenesium>*/