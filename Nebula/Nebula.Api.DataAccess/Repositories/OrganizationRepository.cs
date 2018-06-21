using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class OrganizationRepository : AbstractOrganizationRepository, IOrganizationRepository
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
    <Hash>93e19fd789c2d7491bc3b4a41f772e6d</Hash>
</Codenesium>*/