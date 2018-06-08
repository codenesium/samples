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
                        IDALOrganizationMapper dalorganizationMapper)
                        : base(logger,
                               organizationRepository,
                               organizationModelValidator,
                               bolorganizationMapper,
                               dalorganizationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>182f5a76a4791e65c9cb0a479d3f78c5</Hash>
</Codenesium>*/