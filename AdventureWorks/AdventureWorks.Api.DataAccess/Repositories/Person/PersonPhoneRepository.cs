using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PersonPhoneRepository: AbstractPersonPhoneRepository, IPersonPhoneRepository
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
    <Hash>cb5d07fd7f75146803d03477c6fcd01b</Hash>
</Codenesium>*/