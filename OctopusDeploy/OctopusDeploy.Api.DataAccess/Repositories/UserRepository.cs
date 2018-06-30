using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class UserRepository : AbstractUserRepository, IUserRepository
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
    <Hash>dc458d4cd6bb74c84a41ad4f8b9d5601</Hash>
</Codenesium>*/