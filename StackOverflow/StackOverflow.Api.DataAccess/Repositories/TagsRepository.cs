using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class TagsRepository : AbstractTagsRepository, ITagsRepository
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
    <Hash>ba37f3141ca5665a1fde7edf9b881a5f</Hash>
</Codenesium>*/