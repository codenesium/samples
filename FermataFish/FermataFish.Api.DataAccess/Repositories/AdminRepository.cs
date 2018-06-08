using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
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
    <Hash>9d1c834f58d90f186a1b34c1d9b4cb00</Hash>
</Codenesium>*/