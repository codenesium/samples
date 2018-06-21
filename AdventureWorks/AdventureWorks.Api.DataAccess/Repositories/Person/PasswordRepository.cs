using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class PasswordRepository : AbstractPasswordRepository, IPasswordRepository
        {
                public PasswordRepository(
                        ILogger<PasswordRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>68a8c577db4b43d3fae32dc29c03642c</Hash>
</Codenesium>*/