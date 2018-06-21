using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class PostTypesRepository : AbstractPostTypesRepository, IPostTypesRepository
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
    <Hash>623b0bcb13aab0157cfc92763ea733ed</Hash>
</Codenesium>*/