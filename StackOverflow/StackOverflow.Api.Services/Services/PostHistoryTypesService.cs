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
        public class PostHistoryTypesService : AbstractPostHistoryTypesService, IPostHistoryTypesService
        {
                public PostHistoryTypesService(
                        ILogger<IPostHistoryTypesRepository> logger,
                        IPostHistoryTypesRepository postHistoryTypesRepository,
                        IApiPostHistoryTypesRequestModelValidator postHistoryTypesModelValidator,
                        IBOLPostHistoryTypesMapper bolpostHistoryTypesMapper,
                        IDALPostHistoryTypesMapper dalpostHistoryTypesMapper
                        )
                        : base(logger,
                               postHistoryTypesRepository,
                               postHistoryTypesModelValidator,
                               bolpostHistoryTypesMapper,
                               dalpostHistoryTypesMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f3ff6fdeb938ed75f15078391c76e5ca</Hash>
</Codenesium>*/