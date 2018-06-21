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
        public class VersionInfoService : AbstractVersionInfoService, IVersionInfoService
        {
                public VersionInfoService(
                        ILogger<IVersionInfoRepository> logger,
                        IVersionInfoRepository versionInfoRepository,
                        IApiVersionInfoRequestModelValidator versionInfoModelValidator,
                        IBOLVersionInfoMapper bolversionInfoMapper,
                        IDALVersionInfoMapper dalversionInfoMapper
                        )
                        : base(logger,
                               versionInfoRepository,
                               versionInfoModelValidator,
                               bolversionInfoMapper,
                               dalversionInfoMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>644367ff93e022e756be0e8f9a9f48f3</Hash>
</Codenesium>*/