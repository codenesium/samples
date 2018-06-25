using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
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
    <Hash>2b23edaedf3506b66303b1e9da40a95a</Hash>
</Codenesium>*/