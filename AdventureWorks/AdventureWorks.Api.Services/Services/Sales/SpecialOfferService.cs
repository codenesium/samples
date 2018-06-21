using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class SpecialOfferService : AbstractSpecialOfferService, ISpecialOfferService
        {
                public SpecialOfferService(
                        ILogger<ISpecialOfferRepository> logger,
                        ISpecialOfferRepository specialOfferRepository,
                        IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
                        IBOLSpecialOfferMapper bolspecialOfferMapper,
                        IDALSpecialOfferMapper dalspecialOfferMapper,
                        IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalSpecialOfferProductMapper
                        )
                        : base(logger,
                               specialOfferRepository,
                               specialOfferModelValidator,
                               bolspecialOfferMapper,
                               dalspecialOfferMapper,
                               bolSpecialOfferProductMapper,
                               dalSpecialOfferProductMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bb0d2cd4319ce64d411c625c0a8d7ed0</Hash>
</Codenesium>*/