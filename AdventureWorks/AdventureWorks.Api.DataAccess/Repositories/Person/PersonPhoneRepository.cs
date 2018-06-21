using Codenesium.DataConversionExtensions;
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
    <Hash>0f379cde0cab9d0f3d70d6545785eb77</Hash>
</Codenesium>*/