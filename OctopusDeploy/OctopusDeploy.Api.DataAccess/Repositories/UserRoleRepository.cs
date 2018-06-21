using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class UserRoleRepository : AbstractUserRoleRepository, IUserRoleRepository
        {
                public UserRoleRepository(
                        ILogger<UserRoleRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bcd1202ffa5af93b3e6ab34831d04a0a</Hash>
</Codenesium>*/