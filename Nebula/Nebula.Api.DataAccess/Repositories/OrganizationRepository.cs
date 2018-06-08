using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class OrganizationRepository: AbstractOrganizationRepository, IOrganizationRepository
        {
                public OrganizationRepository(
                        ILogger<OrganizationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>3813168995deda7d68b7789fbb9d693f</Hash>
</Codenesium>*/