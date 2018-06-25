using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class PasswordRepository : AbstractPasswordRepository, IPasswordRepository
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
    <Hash>5b02447e46a37604eda2f229c6e9fd76</Hash>
</Codenesium>*/