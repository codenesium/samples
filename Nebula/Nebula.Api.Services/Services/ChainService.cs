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
                        ILogger<IChainRepository> logger,
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
    <Hash>9c42d9673ec9e7d61c2c7074e0237079</Hash>
</Codenesium>*/