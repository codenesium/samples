using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class TimestampCheckRepository : AbstractTimestampCheckRepository, ITimestampCheckRepository
        {
                public TimestampCheckRepository(
                        ILogger<TimestampCheckRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d3d112b89ca6749c0682ca05c8023f86</Hash>
</Codenesium>*/