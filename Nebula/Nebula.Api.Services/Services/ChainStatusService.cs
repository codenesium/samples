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
                        ILogger<IChainStatusRepository> logger,
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
    <Hash>29823484a5d8cf8424197ebf2b05462e</Hash>
</Codenesium>*/