using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PersonRepository : AbstractPersonRepository, IPersonRepository
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
    <Hash>cf0e2710d1de89cac522d42b0015c42e</Hash>
</Codenesium>*/