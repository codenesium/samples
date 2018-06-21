using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>2948bf1e42bc5d36b91d8d4c489e61d1</Hash>
</Codenesium>*/