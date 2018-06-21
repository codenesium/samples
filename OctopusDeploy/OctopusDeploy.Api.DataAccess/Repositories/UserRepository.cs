using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class UserRepository : AbstractUserRepository, IUserRepository
        {
                public UserRepository(
                        ILogger<UserRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>03d409252170f38479bedb0e2175fff1</Hash>
</Codenesium>*/