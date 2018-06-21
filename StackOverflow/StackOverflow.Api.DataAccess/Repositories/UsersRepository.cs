using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class UsersRepository : AbstractUsersRepository, IUsersRepository
        {
                public UsersRepository(
                        ILogger<UsersRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7c599e4060011af4dcf1362bd4af308f</Hash>
</Codenesium>*/