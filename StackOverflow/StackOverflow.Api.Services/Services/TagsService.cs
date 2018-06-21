using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.Services
{
        public class TagsService : AbstractTagsService, ITagsService
        {
                public TagsService(
                        ILogger<ITagsRepository> logger,
                        ITagsRepository tagsRepository,
                        IApiTagsRequestModelValidator tagsModelValidator,
                        IBOLTagsMapper boltagsMapper,
                        IDALTagsMapper daltagsMapper
                        )
                        : base(logger,
                               tagsRepository,
                               tagsModelValidator,
                               boltagsMapper,
                               daltagsMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>036ccc7a5fe64b2a4f1ccfb20821824c</Hash>
</Codenesium>*/