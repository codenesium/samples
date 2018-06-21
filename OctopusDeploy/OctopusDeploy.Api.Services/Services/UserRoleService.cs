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
    <Hash>d34fe7130828f04f271c2d5413444995</Hash>
</Codenesium>*/