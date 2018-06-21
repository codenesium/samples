using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Services
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
    <Hash>8606970d9be130bf17e10da660b0a64f</Hash>
</Codenesium>*/