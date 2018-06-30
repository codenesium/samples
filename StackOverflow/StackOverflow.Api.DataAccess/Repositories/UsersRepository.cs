using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class UsersRepository : AbstractUsersRepository, IUsersRepository
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
    <Hash>d4db3f84b072130d147927a4137b05bb</Hash>
</Codenesium>*/