using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ContactTypeRepository : AbstractContactTypeRepository, IContactTypeRepository
        {
                public ContactTypeRepository(
                        ILogger<ContactTypeRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e8f11940cdf5612b0d5b2ad836f1dda3</Hash>
</Codenesium>*/