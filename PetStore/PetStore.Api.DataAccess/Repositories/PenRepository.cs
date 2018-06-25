using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public partial class PenRepository : AbstractPenRepository, IPenRepository
        {
                public PenRepository(
                        ILogger<PenRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e49b0b86da1433cc86a0722d3badec57</Hash>
</Codenesium>*/