using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class VersionInfoRepository : AbstractVersionInfoRepository, IVersionInfoRepository
        {
                public VersionInfoRepository(
                        ILogger<VersionInfoRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6fc98da4c638aad23bcb7e65ac3d875f</Hash>
</Codenesium>*/