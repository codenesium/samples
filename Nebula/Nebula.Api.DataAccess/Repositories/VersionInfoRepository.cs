using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
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
    <Hash>c577e472e733d1a52383ec1663b8b57b</Hash>
</Codenesium>*/