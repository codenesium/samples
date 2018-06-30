using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public partial class BreedRepository : AbstractBreedRepository, IBreedRepository
        {
                public BreedRepository(
                        ILogger<BreedRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6423813a4da1fc92053875a10c7417e6</Hash>
</Codenesium>*/