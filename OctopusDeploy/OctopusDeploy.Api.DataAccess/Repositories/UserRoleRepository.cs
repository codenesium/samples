using Codenesium.DataConversionExtensions;
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
    <Hash>d6c94977020e274a6b03a72ee6781f21</Hash>
</Codenesium>*/