using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class CountryRequirementRepository : AbstractCountryRequirementRepository, ICountryRequirementRepository
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
    <Hash>0ab90732fd9ae92ac6af7594e9a6f101</Hash>
</Codenesium>*/