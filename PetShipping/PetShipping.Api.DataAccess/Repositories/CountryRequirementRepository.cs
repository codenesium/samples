using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class CountryRequirementRepository : AbstractCountryRequirementRepository, ICountryRequirementRepository
        {
                public CountryRequirementRepository(
                        ILogger<CountryRequirementRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>753e28b70c86129c5fe82be09289e5e4</Hash>
</Codenesium>*/