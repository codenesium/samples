using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public partial class OrganizationRepository : AbstractOrganizationRepository, IOrganizationRepository
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
    <Hash>6c9f2bea34e72cbfd547f43164ba4bca</Hash>
</Codenesium>*/