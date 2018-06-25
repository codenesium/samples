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
        public partial class UserRoleService : AbstractUserRoleService, IUserRoleService
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
    <Hash>01f2d0206c8d2dc898d17afc1d446903</Hash>
</Codenesium>*/