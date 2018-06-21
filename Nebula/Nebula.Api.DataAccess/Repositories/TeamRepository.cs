using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>aa90bc1f7f724239083ae5bb2afe986a</Hash>
</Codenesium>*/