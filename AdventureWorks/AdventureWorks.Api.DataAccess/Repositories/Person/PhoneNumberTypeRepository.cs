using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PhoneNumberTypeRepository : AbstractPhoneNumberTypeRepository, IPhoneNumberTypeRepository
        {
                public PhoneNumberTypeRepository(
                        ILogger<PhoneNumberTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7d603f98e93444019ea7db17355cb2dc</Hash>
</Codenesium>*/