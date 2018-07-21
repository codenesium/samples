using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class PersonRepository : AbstractPersonRepository, IPersonRepository
        {
                public PersonRepository(
                        ILogger<PersonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>810ef8c918d139cbbca0b6111776050a</Hash>
</Codenesium>*/