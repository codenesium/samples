using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class KeyAllocationRepository: AbstractKeyAllocationRepository, IKeyAllocationRepository
        {
                public KeyAllocationRepository(
                        ILogger<KeyAllocationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>758b01c8a3e05f1b4e13726c941d60bb</Hash>
</Codenesium>*/