using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ContactTypeRepository : AbstractContactTypeRepository, IContactTypeRepository
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
    <Hash>071745b1fdb4a1d02e2a13dc4c20128f</Hash>
</Codenesium>*/