using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class UserRoleRepository : AbstractUserRoleRepository, IUserRoleRepository
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
    <Hash>718f5375982eb31a2fb505e23ec49fec</Hash>
</Codenesium>*/