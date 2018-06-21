using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>1993eb2a88a48b513c48036d8d1f5f33</Hash>
</Codenesium>*/