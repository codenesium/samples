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
        public class UserRoleService: AbstractUserRoleService, IUserRoleService
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
                               daluserRoleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b11f1b4c11e3bd0ce071205c0fead9a1</Hash>
</Codenesium>*/