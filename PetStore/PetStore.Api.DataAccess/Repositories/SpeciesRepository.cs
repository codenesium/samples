using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>721c0d0378edfa9308f722a8f191afc0</Hash>
</Codenesium>*/