using Codenesium.DataConversionExtensions;
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
    <Hash>b245962660e452c0bce164065cf50de4</Hash>
</Codenesium>*/