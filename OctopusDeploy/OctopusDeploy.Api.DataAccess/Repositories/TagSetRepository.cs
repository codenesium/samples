using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class TagSetRepository: AbstractTagSetRepository, ITagSetRepository
        {
                public TagSetRepository(
                        ILogger<TagSetRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e94441c7024ea34062ff4b2cb4177a48</Hash>
</Codenesium>*/