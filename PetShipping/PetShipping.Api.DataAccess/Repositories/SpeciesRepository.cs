using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
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
    <Hash>9fd2707188c3cdca61f798ec6d352340</Hash>
</Codenesium>*/