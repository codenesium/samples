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
        public partial class LinkTypesService : AbstractLinkTypesService, ILinkTypesService
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
    <Hash>46ffe498277915acfc903e494e259ad4</Hash>
</Codenesium>*/