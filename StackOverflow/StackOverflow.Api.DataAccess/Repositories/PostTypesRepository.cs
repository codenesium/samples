using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class PostTypesRepository : AbstractPostTypesRepository, IPostTypesRepository
        {
                public PostTypesRepository(
                        ILogger<PostTypesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>197e752e4f753c0bda34bec736a3977a</Hash>
</Codenesium>*/