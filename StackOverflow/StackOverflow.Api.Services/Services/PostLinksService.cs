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
        public class PostLinksService : AbstractPostLinksService, IPostLinksService
        {
                public PostLinksService(
                        ILogger<IPostLinksRepository> logger,
                        IPostLinksRepository postLinksRepository,
                        IApiPostLinksRequestModelValidator postLinksModelValidator,
                        IBOLPostLinksMapper bolpostLinksMapper,
                        IDALPostLinksMapper dalpostLinksMapper
                        )
                        : base(logger,
                               postLinksRepository,
                               postLinksModelValidator,
                               bolpostLinksMapper,
                               dalpostLinksMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>eccbf97a3e6a73ff77614bb1c00a526f</Hash>
</Codenesium>*/