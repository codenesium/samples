using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class BreedRepository: AbstractBreedRepository, IBreedRepository
        {
                public BreedRepository(
                        ILogger<BreedRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>78eba0084df868db9516d7cbe0948fd5</Hash>
</Codenesium>*/