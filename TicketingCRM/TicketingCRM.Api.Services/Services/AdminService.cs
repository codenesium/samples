using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class AdminService: AbstractAdminService, IAdminService
        {
                public AdminService(
                        ILogger<AdminRepository> logger,
                        IAdminRepository adminRepository,
                        IApiAdminRequestModelValidator adminModelValidator,
                        IBOLAdminMapper boladminMapper,
                        IDALAdminMapper daladminMapper)
                        : base(logger,
                               adminRepository,
                               adminModelValidator,
                               boladminMapper,
                               daladminMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e4c25b1918569fd7a42a3775dc44065b</Hash>
</Codenesium>*/