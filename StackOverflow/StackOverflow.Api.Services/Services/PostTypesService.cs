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
        public partial class PostTypesService : AbstractPostTypesService, IPostTypesService
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
    <Hash>d48e80d953321856ed348de1a3edaf4b</Hash>
</Codenesium>*/