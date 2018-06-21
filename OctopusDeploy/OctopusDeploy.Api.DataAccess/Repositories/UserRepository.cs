using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>77d9ea7f4ff7b46f56eea89c00b9bc9c</Hash>
</Codenesium>*/