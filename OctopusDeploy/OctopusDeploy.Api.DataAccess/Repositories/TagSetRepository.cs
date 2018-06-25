using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class TagSetRepository : AbstractTagSetRepository, ITagSetRepository
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
    <Hash>f546f2b4d13a4d4985808fcdb9ae8fb5</Hash>
</Codenesium>*/