using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class CountryRepository: AbstractCountryRepository, ICountryRepository
        {
                public CountryRepository(
                        ILogger<CountryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>89ee70faac178ea5558373ac3a7e99bb</Hash>
</Codenesium>*/