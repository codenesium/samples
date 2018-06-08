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
                        IDALChainMapper dalchainMapper)
                        : base(logger,
                               chainRepository,
                               chainModelValidator,
                               bolchainMapper,
                               dalchainMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>db4ae08f691ea0964e52c2a39c3edde6</Hash>
</Codenesium>*/