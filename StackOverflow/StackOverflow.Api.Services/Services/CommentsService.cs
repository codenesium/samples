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
        public partial class CommentsService : AbstractCommentsService, ICommentsService
        {
                public CommentsService(
                        ILogger<ICommentsRepository> logger,
                        ICommentsRepository commentsRepository,
                        IApiCommentsRequestModelValidator commentsModelValidator,
                        IBOLCommentsMapper bolcommentsMapper,
                        IDALCommentsMapper dalcommentsMapper
                        )
                        : base(logger,
                               commentsRepository,
                               commentsModelValidator,
                               bolcommentsMapper,
                               dalcommentsMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>237cfebb7515714f594752130709e3d4</Hash>
</Codenesium>*/