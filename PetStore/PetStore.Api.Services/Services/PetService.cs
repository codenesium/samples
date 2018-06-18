using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
        public class PetService: AbstractPetService, IPetService
        {
                public PetService(
                        ILogger<IPetRepository> logger,
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
    <Hash>1ab775403eec69b0a523ace26431818c</Hash>
</Codenesium>*/