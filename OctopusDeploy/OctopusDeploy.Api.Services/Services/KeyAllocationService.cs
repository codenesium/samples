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
                        ILogger<KeyAllocationRepository> logger,
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
    <Hash>02aecfaa227bbe55a814a6438ca25249</Hash>
</Codenesium>*/