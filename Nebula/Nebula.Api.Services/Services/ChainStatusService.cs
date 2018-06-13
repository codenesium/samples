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
        public class ChainStatusService: AbstractChainStatusService, IChainStatusService
        {
                public ChainStatusService(
                        ILogger<ChainStatusRepository> logger,
                        IChainStatusRepository chainStatusRepository,
                        IApiChainStatusRequestModelValidator chainStatusModelValidator,
                        IBOLChainStatusMapper bolchainStatusMapper,
                        IDALChainStatusMapper dalchainStatusMapper
                        ,
                        IBOLChainMapper bolChainMapper,
                        IDALChainMapper dalChainMapper

                        )
                        : base(logger,
                               chainStatusRepository,
                               chainStatusModelValidator,
                               bolchainStatusMapper,
                               dalchainStatusMapper
                               ,
                               bolChainMapper,
                               dalChainMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f437fd7a3674bd4cb418d56c9d232264</Hash>
</Codenesium>*/