using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
{
        public class VersionInfoRepository: AbstractVersionInfoRepository, IVersionInfoRepository
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
    <Hash>fc2e30ae6f17cb5c2d1cd768fc4b0973</Hash>
</Codenesium>*/