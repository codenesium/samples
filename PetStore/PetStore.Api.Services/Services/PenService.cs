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
        public class PenService : AbstractPenService, IPenService
        {
                public PenService(
                        ILogger<IPenRepository> logger,
                        IPenRepository penRepository,
                        IApiPenRequestModelValidator penModelValidator,
                        IBOLPenMapper bolpenMapper,
                        IDALPenMapper dalpenMapper,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper
                        )
                        : base(logger,
                               penRepository,
                               penModelValidator,
                               bolpenMapper,
                               dalpenMapper,
                               bolPetMapper,
                               dalPetMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>90b424c7006fd48388fb148ea5b33ad7</Hash>
</Codenesium>*/