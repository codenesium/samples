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
                        ILogger<IPenRepository> logger,
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
    <Hash>7c12afc62b82ab0aec4650cc61cf3b2a</Hash>
</Codenesium>*/