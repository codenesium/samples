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
                        ILogger<SpeciesRepository> logger,
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
    <Hash>01a5502019a7f83404cde5fb5ef85821</Hash>
</Codenesium>*/