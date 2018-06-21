using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class TagSetService : AbstractTagSetService, ITagSetService
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
                               daltagSetMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>57fdf8ce0130c5b122bd294f837a39d1</Hash>
</Codenesium>*/