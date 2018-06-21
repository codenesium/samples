using Codenesium.DataConversionExtensions;
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
    <Hash>eaf6b8d15a86588b91a01a92373ca3c1</Hash>
</Codenesium>*/