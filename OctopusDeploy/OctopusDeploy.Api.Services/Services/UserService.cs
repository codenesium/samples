using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class UserService : AbstractUserService, IUserService
        {
                public UserService(
                        ILogger<IUserRepository> logger,
                        IUserRepository userRepository,
                        IApiUserRequestModelValidator userModelValidator,
                        IBOLUserMapper boluserMapper,
                        IDALUserMapper daluserMapper
                        )
                        : base(logger,
                               userRepository,
                               userModelValidator,
                               boluserMapper,
                               daluserMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5ded2b7b981722d81513386cfad76639</Hash>
</Codenesium>*/