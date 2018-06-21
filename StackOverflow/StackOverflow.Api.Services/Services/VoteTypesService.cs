using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
        public class VoteTypesService : AbstractVoteTypesService, IVoteTypesService
        {
                public VoteTypesService(
                        ILogger<IVoteTypesRepository> logger,
                        IVoteTypesRepository voteTypesRepository,
                        IApiVoteTypesRequestModelValidator voteTypesModelValidator,
                        IBOLVoteTypesMapper bolvoteTypesMapper,
                        IDALVoteTypesMapper dalvoteTypesMapper
                        )
                        : base(logger,
                               voteTypesRepository,
                               voteTypesModelValidator,
                               bolvoteTypesMapper,
                               dalvoteTypesMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fcc4669d79ff544eaaf8c145705db45d</Hash>
</Codenesium>*/