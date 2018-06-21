using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PersonPhoneRepository : AbstractPersonPhoneRepository, IPersonPhoneRepository
        {
                public PersonPhoneRepository(
                        ILogger<PersonPhoneRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6a21c2f7e2fb02f229ab07c62ed82f22</Hash>
</Codenesium>*/