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
        public class VersionInfoService: AbstractVersionInfoService, IVersionInfoService
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
                               dalversionInfoMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e1a122efc4dde10e4b692592c94d6371</Hash>
</Codenesium>*/