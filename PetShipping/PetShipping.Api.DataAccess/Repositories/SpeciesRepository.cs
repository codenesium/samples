using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class SpeciesRepository : AbstractSpeciesRepository, ISpeciesRepository
        {
                public SpeciesRepository(
                        ILogger<SpeciesRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a1d466244a0fe7a70e990c3447c9eea8</Hash>
</Codenesium>*/