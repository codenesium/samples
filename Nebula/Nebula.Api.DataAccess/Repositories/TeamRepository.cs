using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class TeamRepository: AbstractTeamRepository, ITeamRepository
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
    <Hash>2d64eead003d4222ccf794eb5bd1befc</Hash>
</Codenesium>*/