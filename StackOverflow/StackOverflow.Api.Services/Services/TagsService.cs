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
        public partial class TagsService : AbstractTagsService, ITagsService
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
    <Hash>949248c31d3b8f0bbbae09785614dc5a</Hash>
</Codenesium>*/