using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class KeyAllocationService : AbstractKeyAllocationService, IKeyAllocationService
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
                               dalkeyAllocationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>41bb46b103ed8ef44f937ee0c38321df</Hash>
</Codenesium>*/