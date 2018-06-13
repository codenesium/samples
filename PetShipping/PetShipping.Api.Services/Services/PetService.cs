using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public class PetService: AbstractPetService, IPetService
        {
                public PetService(
                        ILogger<PetRepository> logger,
                        IPetRepository petRepository,
                        IApiPetRequestModelValidator petModelValidator,
                        IBOLPetMapper bolpetMapper,
                        IDALPetMapper dalpetMapper
                        ,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper

                        )
                        : base(logger,
                               petRepository,
                               petModelValidator,
                               bolpetMapper,
                               dalpetMapper
                               ,
                               bolSaleMapper,
                               dalSaleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2a25fff8c10097472527efa7a7b6dc50</Hash>
</Codenesium>*/