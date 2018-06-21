using Codenesium.DataConversionExtensions.AspNetCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FileServiceNS.Api.Services
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
    <Hash>d88c5bc6f2a762021929c46c5f3a59f9</Hash>
</Codenesium>*/