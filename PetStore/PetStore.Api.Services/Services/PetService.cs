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
    <Hash>566102c772f5408f6168aeef20b0859d</Hash>
</Codenesium>*/