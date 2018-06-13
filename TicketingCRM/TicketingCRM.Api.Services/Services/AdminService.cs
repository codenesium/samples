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
                        IDALAdminMapper daladminMapper
                        ,
                        IBOLVenueMapper bolVenueMapper,
                        IDALVenueMapper dalVenueMapper

                        )
                        : base(logger,
                               adminRepository,
                               adminModelValidator,
                               boladminMapper,
                               daladminMapper
                               ,
                               bolVenueMapper,
                               dalVenueMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>7ff631508999ea3d01ff576554a90e64</Hash>
</Codenesium>*/