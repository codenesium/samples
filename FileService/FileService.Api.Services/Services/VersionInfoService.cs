using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
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
    <Hash>4d3218376d34ec41bf5d15d726b1241b</Hash>
</Codenesium>*/