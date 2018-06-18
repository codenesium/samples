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
                        ILogger<ISpecialOfferRepository> logger,
                        ISpecialOfferRepository specialOfferRepository,
                        IApiSpecialOfferRequestModelValidator specialOfferModelValidator,
                        IBOLSpecialOfferMapper bolspecialOfferMapper,
                        IDALSpecialOfferMapper dalspecialOfferMapper
                        ,
                        IBOLSpecialOfferProductMapper bolSpecialOfferProductMapper,
                        IDALSpecialOfferProductMapper dalSpecialOfferProductMapper

                        )
                        : base(logger,
                               specialOfferRepository,
                               specialOfferModelValidator,
                               bolspecialOfferMapper,
                               dalspecialOfferMapper
                               ,
                               bolSpecialOfferProductMapper,
                               dalSpecialOfferProductMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>3cc6a625d3bd641ccf448fc607bede52</Hash>
</Codenesium>*/