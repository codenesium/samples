using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class TeamRepository : AbstractTeamRepository, ITeamRepository
        {
                public TeamRepository(
                        ILogger<TeamRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>29df55abd3c88a82e96e99204ed04f19</Hash>
</Codenesium>*/