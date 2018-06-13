using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.DataAccess
{
        public class AdminRepository: AbstractAdminRepository, IAdminRepository
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
    <Hash>4e39174661b1599959cacf4782d6ce23</Hash>
</Codenesium>*/