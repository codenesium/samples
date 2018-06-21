using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class PenRepository : AbstractPenRepository, IPenRepository
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
    <Hash>52f07ae97943c1949d0883f87a0e63f4</Hash>
</Codenesium>*/