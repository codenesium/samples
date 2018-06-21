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
        public class VotesService : AbstractVotesService, IVotesService
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
    <Hash>70d99d363caea314ed28f469d4726f66</Hash>
</Codenesium>*/