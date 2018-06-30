using Codenesium.DataConversionExtensions;
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
        public partial class AdminService : AbstractAdminService, IAdminService
        {
                public AdminService(
                        ILogger<IAdminRepository> logger,
                        IAdminRepository adminRepository,
                        IApiAdminRequestModelValidator adminModelValidator,
                        IBOLAdminMapper boladminMapper,
                        IDALAdminMapper daladminMapper,
                        IBOLVenueMapper bolVenueMapper,
                        IDALVenueMapper dalVenueMapper
                        )
                        : base(logger,
                               adminRepository,
                               adminModelValidator,
                               boladminMapper,
                               daladminMapper,
                               bolVenueMapper,
                               dalVenueMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8243f632e4683b20ad01f78ba90a00c6</Hash>
</Codenesium>*/