using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class PenRepository: AbstractPenRepository, IPenRepository
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
    <Hash>ad26f6d9f792ef1f2ab60061f3ef4e69</Hash>
</Codenesium>*/