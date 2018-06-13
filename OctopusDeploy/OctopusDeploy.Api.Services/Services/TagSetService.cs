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
                        ILogger<TagSetRepository> logger,
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
    <Hash>6e76a98a22c0d26496a6fbdbb6f41b20</Hash>
</Codenesium>*/