using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public partial class AdminRepository : AbstractAdminRepository, IAdminRepository
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
    <Hash>73a5138a855a0cb654d2dfa09902fceb</Hash>
</Codenesium>*/