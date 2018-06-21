using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>c95848e3264efdb28471285493db5f04</Hash>
</Codenesium>*/