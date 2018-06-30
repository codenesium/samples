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
        public partial class VotesService : AbstractVotesService, IVotesService
        {
                public VotesService(
                        ILogger<IVotesRepository> logger,
                        IVotesRepository votesRepository,
                        IApiVotesRequestModelValidator votesModelValidator,
                        IBOLVotesMapper bolvotesMapper,
                        IDALVotesMapper dalvotesMapper
                        )
                        : base(logger,
                               votesRepository,
                               votesModelValidator,
                               bolvotesMapper,
                               dalvotesMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>435678db7be47b3cdc3cccacb86e2e4a</Hash>
</Codenesium>*/