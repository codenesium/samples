using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.Services
{
        public class ClaspService : AbstractClaspService, IClaspService
        {
                public ClaspService(
                        ILogger<IClaspRepository> logger,
                        IClaspRepository claspRepository,
                        IApiClaspRequestModelValidator claspModelValidator,
                        IBOLClaspMapper bolclaspMapper,
                        IDALClaspMapper dalclaspMapper
                        )
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
    <Hash>fbf3a6c3a73a936aec88e1b3f509dc11</Hash>
</Codenesium>*/