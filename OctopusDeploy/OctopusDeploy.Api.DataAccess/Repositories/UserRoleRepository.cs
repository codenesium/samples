using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class UserRoleRepository: AbstractUserRoleRepository, IUserRoleRepository
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
    <Hash>6cd520ae59bb54530b948f4211d7c1d0</Hash>
</Codenesium>*/