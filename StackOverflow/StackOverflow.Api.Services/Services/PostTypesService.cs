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
        public class PostTypesService : AbstractPostTypesService, IPostTypesService
        {
                public PostTypesService(
                        ILogger<IPostTypesRepository> logger,
                        IPostTypesRepository postTypesRepository,
                        IApiPostTypesRequestModelValidator postTypesModelValidator,
                        IBOLPostTypesMapper bolpostTypesMapper,
                        IDALPostTypesMapper dalpostTypesMapper
                        )
                        : base(logger,
                               postTypesRepository,
                               postTypesModelValidator,
                               bolpostTypesMapper,
                               dalpostTypesMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>62311828a929db3949ac19e5fc840b58</Hash>
</Codenesium>*/