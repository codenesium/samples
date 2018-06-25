using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class KeyAllocationRepository : AbstractKeyAllocationRepository, IKeyAllocationRepository
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
    <Hash>1de0e0e9ed9320e8ed364343b7b28254</Hash>
</Codenesium>*/