using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class SpecialOfferService: AbstractSpecialOfferService, ISpecialOfferService
        {
                public SpecialOfferService(
                        ILogger<SpecialOfferRepository> logger,
                        ISpecialOfferRepository specialOfferRepository,
                        IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
                        IBOLSpecialOfferMapper bolspecialOfferMapper,
                        IDALSpecialOfferMapper dalspecialOfferMapper)
                        : base(logger,
                               specialOfferRepository,
                               specialOfferModelValidator,
                               bolspecialOfferMapper,
                               dalspecialOfferMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4ee56b1abaa6bd08b295cd843a07abc7</Hash>
</Codenesium>*/