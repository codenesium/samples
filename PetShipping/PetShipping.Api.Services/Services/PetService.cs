using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Services
{
        public class PetService : AbstractPetService, IPetService
        {
                public PetService(
                        ILogger<IPetRepository> logger,
                        IPetRepository petRepository,
                        IApiPetRequestModelValidator petModelValidator,
                        IBOLPetMapper bolpetMapper,
                        IDALPetMapper dalpetMapper,
                        IBOLSaleMapper bolSaleMapper,
                        IDALSaleMapper dalSaleMapper
                        )
                        : base(logger,
                               petRepository,
                               petModelValidator,
                               bolpetMapper,
                               dalpetMapper,
                               bolSaleMapper,
                               dalSaleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>2a48e43f0e92a7419742d1ff63baf218</Hash>
</Codenesium>*/