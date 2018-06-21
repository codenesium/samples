using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class VoteTypesRepository : AbstractVoteTypesRepository, IVoteTypesRepository
        {
                public VoteTypesRepository(
                        ILogger<VoteTypesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1a212664de20128e56e396e9db47cb86</Hash>
</Codenesium>*/