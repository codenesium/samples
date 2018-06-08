using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class CountryRequirementRepository: AbstractCountryRequirementRepository, ICountryRequirementRepository
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
    <Hash>708fb9801a52ea83acfae45ad4daa632</Hash>
</Codenesium>*/