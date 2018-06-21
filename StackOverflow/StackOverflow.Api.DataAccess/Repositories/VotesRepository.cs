using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class VotesRepository : AbstractVotesRepository, IVotesRepository
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
    <Hash>03fee5cdb65e4bb13de436c2c91533e8</Hash>
</Codenesium>*/