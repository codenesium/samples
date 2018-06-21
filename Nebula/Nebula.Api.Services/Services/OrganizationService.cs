using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
        public class OrganizationService : AbstractOrganizationService, IOrganizationService
        {
                public OrganizationService(
                        ILogger<IOrganizationRepository> logger,
                        IOrganizationRepository organizationRepository,
                        IApiOrganizationRequestModelValidator organizationModelValidator,
                        IBOLOrganizationMapper bolorganizationMapper,
                        IDALOrganizationMapper dalorganizationMapper,
                        IBOLTeamMapper bolTeamMapper,
                        IDALTeamMapper dalTeamMapper
                        )
                        : base(logger,
                               organizationRepository,
                               organizationModelValidator,
                               bolorganizationMapper,
                               dalorganizationMapper,
                               bolTeamMapper,
                               dalTeamMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7e5301c1696f6592e97f843a6dff3785</Hash>
</Codenesium>*/