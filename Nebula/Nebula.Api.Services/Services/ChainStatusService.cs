using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class ChainStatusService : AbstractChainStatusService, IChainStatusService
        {
                public ChainStatusService(
                        ILogger<IChainStatusRepository> logger,
                        IChainStatusRepository chainStatusRepository,
                        IApiChainStatusRequestModelValidator chainStatusModelValidator,
                        IBOLChainStatusMapper bolchainStatusMapper,
                        IDALChainStatusMapper dalchainStatusMapper,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper
                        )
                        : base(logger,
                               chainStatusRepository,
                               chainStatusModelValidator,
                               bolchainStatusMapper,
                               dalchainStatusMapper,
                               bolChainMapper,
                               dalChainMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1942a9f4972589b0d67b109405c2356e</Hash>
</Codenesium>*/