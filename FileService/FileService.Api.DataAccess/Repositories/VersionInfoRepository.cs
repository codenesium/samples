using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>40c471719a2e0a9f0c6052d2890a1a56</Hash>
</Codenesium>*/