using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class TagSetRepository : AbstractTagSetRepository, ITagSetRepository
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
    <Hash>7b1580d2376237656e63e66010477990</Hash>
</Codenesium>*/