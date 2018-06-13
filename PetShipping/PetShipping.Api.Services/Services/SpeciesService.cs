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
        public class SpeciesService: AbstractSpeciesService, ISpeciesService
        {
                public SpeciesService(
                        ILogger<SpeciesRepository> logger,
                        ISpeciesRepository speciesRepository,
                        IApiSpeciesRequestModelValidator speciesModelValidator,
                        IBOLSpeciesMapper bolspeciesMapper,
                        IDALSpeciesMapper dalspeciesMapper
                        ,
                        IBOLBreedMapper bolBreedMapper,
                        IDALBreedMapper dalBreedMapper

                        )
                        : base(logger,
                               speciesRepository,
                               speciesModelValidator,
                               bolspeciesMapper,
                               dalspeciesMapper
                               ,
                               bolBreedMapper,
                               dalBreedMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>6935283b58a0cfd9347b7b8119e72e08</Hash>
</Codenesium>*/