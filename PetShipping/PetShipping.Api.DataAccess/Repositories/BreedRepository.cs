using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class BreedRepository: AbstractBreedRepository, IBreedRepository
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
    <Hash>59505ad3406de09c54a5d9bc7cbc9a14</Hash>
</Codenesium>*/