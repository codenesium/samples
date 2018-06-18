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
        public class SpeciesService: AbstractSpeciesService, ISpeciesService
        {
                public SpeciesService(
                        ILogger<ISpeciesRepository> logger,
                        ISpeciesRepository speciesRepository,
                        IApiSpeciesRequestModelValidator speciesModelValidator,
                        IBOLSpeciesMapper bolspeciesMapper,
                        IDALSpeciesMapper dalspeciesMapper
                        ,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper

                        )
                        : base(logger,
                               speciesRepository,
                               speciesModelValidator,
                               bolspeciesMapper,
                               dalspeciesMapper
                               ,
                               bolPetMapper,
                               dalPetMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>ab0ff586be0e16ea40121bf326f08949</Hash>
</Codenesium>*/