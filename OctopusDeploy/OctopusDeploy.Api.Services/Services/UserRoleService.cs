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
        public class UserRoleService : AbstractUserRoleService, IUserRoleService
        {
                public UserRoleService(
                        ILogger<IUserRoleRepository> logger,
                        IUserRoleRepository userRoleRepository,
                        IApiUserRoleRequestModelValidator userRoleModelValidator,
                        IBOLUserRoleMapper boluserRoleMapper,
                        IDALUserRoleMapper daluserRoleMapper
                        )
                        : base(logger,
                               userRoleRepository,
                               userRoleModelValidator,
                               boluserRoleMapper,
                               daluserRoleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa07b73b8cd0b4e5156adab229fb8fba</Hash>
</Codenesium>*/