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
                               daluserMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>6754a7dc0332af07f4a525eedcccff1a</Hash>
</Codenesium>*/