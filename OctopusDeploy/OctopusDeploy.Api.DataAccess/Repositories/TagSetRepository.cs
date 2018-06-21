using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>20edd0977b3ce48931a6aa8eb19503c7</Hash>
</Codenesium>*/