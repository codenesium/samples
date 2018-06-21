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
        public class SpeciesService : AbstractSpeciesService, ISpeciesService
        {
                public SpeciesService(
                        ILogger<ISpeciesRepository> logger,
                        ISpeciesRepository speciesRepository,
                        IApiSpeciesRequestModelValidator speciesModelValidator,
                        IBOLSpeciesMapper bolspeciesMapper,
                        IDALSpeciesMapper dalspeciesMapper,
                        IBOLPetMapper bolPetMapper,
                        IDALPetMapper dalPetMapper
                        )
                        : base(logger,
                               speciesRepository,
                               speciesModelValidator,
                               bolspeciesMapper,
                               dalspeciesMapper,
                               bolPetMapper,
                               dalPetMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>7fa5c847fffb798e4e908bd325f8f441</Hash>
</Codenesium>*/