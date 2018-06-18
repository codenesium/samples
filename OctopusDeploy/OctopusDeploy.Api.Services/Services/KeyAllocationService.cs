using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class KeyAllocationService: AbstractKeyAllocationService, IKeyAllocationService
        {
                public KeyAllocationService(
                        ILogger<IKeyAllocationRepository> logger,
                        IKeyAllocationRepository keyAllocationRepository,
                        IApiKeyAllocationRequestModelValidator keyAllocationModelValidator,
                        IBOLKeyAllocationMapper bolkeyAllocationMapper,
                        IDALKeyAllocationMapper dalkeyAllocationMapper

                        )
                        : base(logger,
                               keyAllocationRepository,
                               keyAllocationModelValidator,
                               bolkeyAllocationMapper,
                               dalkeyAllocationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>a6042270bd687dcfd5ad254a04aaf5af</Hash>
</Codenesium>*/