using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class TagsRepository : AbstractTagsRepository, ITagsRepository
        {
                public TagsRepository(
                        ILogger<TagsRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>51e92561adc6fddefa5b5acd1d61d13a</Hash>
</Codenesium>*/