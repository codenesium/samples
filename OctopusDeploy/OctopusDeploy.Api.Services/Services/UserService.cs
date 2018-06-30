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
        public partial class UserService : AbstractUserService, IUserService
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
    <Hash>3f27fc5840ca64e4296936f3cd844508</Hash>
</Codenesium>*/