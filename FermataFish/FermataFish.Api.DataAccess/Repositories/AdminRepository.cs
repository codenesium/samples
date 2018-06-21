using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
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
    <Hash>d5c3b7c87bc32793334bc4861a0a9ea3</Hash>
</Codenesium>*/