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
                        IDALChainStatusMapper dalchainStatusMapper)
                        : base(logger,
                               chainStatusRepository,
                               chainStatusModelValidator,
                               bolchainStatusMapper,
                               dalchainStatusMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7f448804e8b02548aab30c5c0e1ebc25</Hash>
</Codenesium>*/