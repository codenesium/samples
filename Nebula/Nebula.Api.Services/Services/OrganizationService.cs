using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class OrganizationService: AbstractOrganizationService, IOrganizationService
        {
                public OrganizationService(
                        ILogger<OrganizationRepository> logger,
                        IOrganizationRepository organizationRepository,
                        IApiOrganizationRequestModelValidator organizationModelValidator,
                        IBOLOrganizationMapper bolorganizationMapper,
                        IDALOrganizationMapper dalorganizationMapper
                        ,
                        IBOLTeamMapper bolTeamMapper,
                        IDALTeamMapper dalTeamMapper

                        )
                        : base(logger,
                               organizationRepository,
                               organizationModelValidator,
                               bolorganizationMapper,
                               dalorganizationMapper
                               ,
                               bolTeamMapper,
                               dalTeamMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f066c97e79aa784bdfd7262fb40e718a</Hash>
</Codenesium>*/