using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class UserService: AbstractUserService, IUserService
        {
                public UserService(
                        ILogger<UserRepository> logger,
                        IUserRepository userRepository,
                        IApiUserRequestModelValidator userModelValidator,
                        IBOLUserMapper boluserMapper,
                        IDALUserMapper daluserMapper

                        )
                        : base(logger,
                               userRepository,
                               userModelValidator,
                               boluserMapper,
                               daluserMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>02f3f92bf5cbd80b75bc91b7cbd9c16f</Hash>
</Codenesium>*/