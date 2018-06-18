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
                        ILogger<IAdminRepository> logger,
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
    <Hash>16b53a9e140f144589be13a58c7b0925</Hash>
</Codenesium>*/