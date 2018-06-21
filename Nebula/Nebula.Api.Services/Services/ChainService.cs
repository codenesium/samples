using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
        public class ChainService : AbstractChainService, IChainService
        {
                public ChainService(
                        ILogger<IChainRepository> logger,
                        IChainRepository chainRepository,
                        IApiChainRequestModelValidator chainModelValidator,
                        IBOLChainMapper bolchainMapper,
                        IDALChainMapper dalchainMapper,
                        IBOLClaspMapper bolClaspMapper,
                        IDALClaspMapper dalClaspMapper,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper
                        )
                        : base(logger,
                               chainRepository,
                               chainModelValidator,
                               bolchainMapper,
                               dalchainMapper,
                               bolClaspMapper,
                               dalClaspMapper,
                               bolLinkMapper,
                               dalLinkMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b5104dcc54a66f28c4a9643dbb5b3446</Hash>
</Codenesium>*/