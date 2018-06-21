using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
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
    <Hash>23c968c65e7bc073c061166e55d31e98</Hash>
</Codenesium>*/