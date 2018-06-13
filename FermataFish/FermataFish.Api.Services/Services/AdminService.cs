using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class AdminService: AbstractAdminService, IAdminService
        {
                public AdminService(
                        ILogger<AdminRepository> logger,
                        IAdminRepository adminRepository,
                        IApiAdminRequestModelValidator adminModelValidator,
                        IBOLAdminMapper boladminMapper,
                        IDALAdminMapper daladminMapper

                        )
                        : base(logger,
                               adminRepository,
                               adminModelValidator,
                               boladminMapper,
                               daladminMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>762eade70d52c6de92978333f7920077</Hash>
</Codenesium>*/