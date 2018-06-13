using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ChainService: AbstractChainService, IChainService
        {
                public ChainService(
                        ILogger<ChainRepository> logger,
                        IChainRepository chainRepository,
                        IApiChainRequestModelValidator chainModelValidator,
                        IBOLChainMapper bolchainMapper,
                        IDALChainMapper dalchainMapper
                        ,
                        IBOLClaspMapper bolClaspMapper,
                        IDALClaspMapper dalClaspMapper
                        ,
                        IBOLLinkMapper bolLinkMapper,
                        IDALLinkMapper dalLinkMapper

                        )
                        : base(logger,
                               chainRepository,
                               chainModelValidator,
                               bolchainMapper,
                               dalchainMapper
                               ,
                               bolClaspMapper,
                               dalClaspMapper
                               ,
                               bolLinkMapper,
                               dalLinkMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>070e1eed9bd4c69c75452579e24995d8</Hash>
</Codenesium>*/