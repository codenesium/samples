using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class VoteTypesRepository : AbstractVoteTypesRepository, IVoteTypesRepository
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
    <Hash>0883238270e9cc4d96c8c01393bc19d5</Hash>
</Codenesium>*/