using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>d5caa00c8d828a6fed039ee6a9cb42fd</Hash>
</Codenesium>*/