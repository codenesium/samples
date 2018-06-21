using Codenesium.DataConversionExtensions;
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
    <Hash>a0e9a1432f5fb8d3d437834cebe2a8f4</Hash>
</Codenesium>*/