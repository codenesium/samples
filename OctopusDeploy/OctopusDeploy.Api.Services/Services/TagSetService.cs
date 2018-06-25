using Codenesium.DataConversionExtensions;
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
        public partial class TagSetService : AbstractTagSetService, ITagSetService
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
    <Hash>044b7aa679cd1e2e93502ac136cf60bd</Hash>
</Codenesium>*/