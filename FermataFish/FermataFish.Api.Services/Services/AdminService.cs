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
                        ILogger<IAdminRepository> logger,
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
    <Hash>ed93e48bf11439d6636e41eceb3d7c77</Hash>
</Codenesium>*/