using Codenesium.DataConversionExtensions;
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
    <Hash>537507cc28fc4f9f976539de6504face</Hash>
</Codenesium>*/