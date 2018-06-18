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
                        ILogger<IOrganizationRepository> logger,
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
    <Hash>ee28c1a24969eef7951c372f1fb51d78</Hash>
</Codenesium>*/