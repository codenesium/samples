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
                        ILogger<UserRoleRepository> logger,
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
    <Hash>d3c45cc8f00e6e2942b7524376001370</Hash>
</Codenesium>*/