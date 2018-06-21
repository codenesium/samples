using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class AdminRepository : AbstractAdminRepository, IAdminRepository
        {
                public AdminRepository(
                        ILogger<AdminRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2458c2031788eef7223fdaa2c70bd7aa</Hash>
</Codenesium>*/