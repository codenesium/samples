using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class TagSetService: AbstractTagSetService, ITagSetService
        {
                public TagSetService(
                        ILogger<ITagSetRepository> logger,
                        ITagSetRepository tagSetRepository,
                        IApiTagSetRequestModelValidator tagSetModelValidator,
                        IBOLTagSetMapper boltagSetMapper,
                        IDALTagSetMapper daltagSetMapper

                        )
                        : base(logger,
                               tagSetRepository,
                               tagSetModelValidator,
                               boltagSetMapper,
                               daltagSetMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>d4cd0771e979c868b9a1d63a659df99a</Hash>
</Codenesium>*/