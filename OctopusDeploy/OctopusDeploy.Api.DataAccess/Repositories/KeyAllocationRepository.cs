using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class KeyAllocationRepository : AbstractKeyAllocationRepository, IKeyAllocationRepository
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
    <Hash>f940e5e879b087b37d8ea4b9846d6db1</Hash>
</Codenesium>*/