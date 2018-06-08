using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class SpeciesRepository: AbstractSpeciesRepository, ISpeciesRepository
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
    <Hash>cd3be3aa4545835a4322a34e55b2ad5c</Hash>
</Codenesium>*/