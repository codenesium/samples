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
        public class SpeciesService : AbstractSpeciesService, ISpeciesService
        {
                public SpeciesService(
                        ILogger<ISpeciesRepository> logger,
                        ISpeciesRepository speciesRepository,
                        IApiSpeciesRequestModelValidator speciesModelValidator,
                        IBOLSpeciesMapper bolspeciesMapper,
                        IDALSpeciesMapper dalspeciesMapper,
                        IBOLBreedMapper bolBreedMapper,
                        IDALBreedMapper dalBreedMapper
                        )
                        : base(logger,
                               speciesRepository,
                               speciesModelValidator,
                               bolspeciesMapper,
                               dalspeciesMapper,
                               bolBreedMapper,
                               dalBreedMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a78b631b21698fe1e94999c8877c8e66</Hash>
</Codenesium>*/