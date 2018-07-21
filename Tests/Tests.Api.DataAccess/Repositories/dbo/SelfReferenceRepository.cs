using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace TestsNS.Api.DataAccess
{
        public partial class SelfReferenceRepository : AbstractSelfReferenceRepository, ISelfReferenceRepository
        {
                public SelfReferenceRepository(
                        ILogger<SelfReferenceRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a6fa1fa8abc22cf5c24bfc9a8face931</Hash>
</Codenesium>*/