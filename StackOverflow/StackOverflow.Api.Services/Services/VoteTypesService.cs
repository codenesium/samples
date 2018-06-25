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
        public partial class VoteTypesService : AbstractVoteTypesService, IVoteTypesService
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
    <Hash>f56b408e43fb70cca3f84d7806ddc5ca</Hash>
</Codenesium>*/