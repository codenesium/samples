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
        public class PenService: AbstractPenService, IPenService
        {
                public PenService(
                        ILogger<PenRepository> logger,
                        IPenRepository penRepository,
                        IApiPenRequestModelValidator penModelValidator,
                        IBOLPenMapper bolpenMapper,
                        IDALPenMapper dalpenMapper
                        ,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper

                        )
                        : base(logger,
                               penRepository,
                               penModelValidator,
                               bolpenMapper,
                               dalpenMapper
                               ,
                               bolPetMapper,
                               dalPetMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2587f2f7869bb51a6d917ed21db1dd76</Hash>
</Codenesium>*/