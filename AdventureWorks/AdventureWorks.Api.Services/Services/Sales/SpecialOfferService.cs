using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class SpecialOfferService : AbstractSpecialOfferService, ISpecialOfferService
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
    <Hash>cc38abb78c6a468c5ad977627f79b5ff</Hash>
</Codenesium>*/