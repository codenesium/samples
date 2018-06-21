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
        public class LinkTypesService : AbstractLinkTypesService, ILinkTypesService
        {
                public LinkTypesService(
                        ILogger<ILinkTypesRepository> logger,
                        ILinkTypesRepository linkTypesRepository,
                        IApiLinkTypesRequestModelValidator linkTypesModelValidator,
                        IBOLLinkTypesMapper bollinkTypesMapper,
                        IDALLinkTypesMapper dallinkTypesMapper
                        )
                        : base(logger,
                               linkTypesRepository,
                               linkTypesModelValidator,
                               bollinkTypesMapper,
                               dallinkTypesMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9630671f3e9f4a784e2df63c48d57390</Hash>
</Codenesium>*/