using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public class ClaspService: AbstractClaspService, IClaspService
        {
                public ClaspService(
                        ILogger<ClaspRepository> logger,
                        IClaspRepository claspRepository,
                        IApiClaspRequestModelValidator claspModelValidator,
                        IBOLClaspMapper bolclaspMapper,
                        IDALClaspMapper dalclaspMapper)
                        : base(logger,
                               claspRepository,
                               claspModelValidator,
                               bolclaspMapper,
                               dalclaspMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>37a5c7768a71cd3627678de40964d824</Hash>
</Codenesium>*/