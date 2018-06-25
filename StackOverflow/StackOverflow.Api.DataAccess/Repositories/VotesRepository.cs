using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class VotesRepository : AbstractVotesRepository, IVotesRepository
        {
                public VotesRepository(
                        ILogger<VotesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4e9229edd886805174876dc4061cbea0</Hash>
</Codenesium>*/