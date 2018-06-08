using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class PetRepository: AbstractPetRepository, IPetRepository
        {
                public PetRepository(
                        ILogger<PetRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0ce0bb83f2173d5a9d16d1ea9dc2a4c0</Hash>
</Codenesium>*/