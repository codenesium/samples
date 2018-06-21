using Codenesium.DataConversionExtensions;
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
    <Hash>4aaaf436e658e7533ebd8f8d62cb88bb</Hash>
</Codenesium>*/