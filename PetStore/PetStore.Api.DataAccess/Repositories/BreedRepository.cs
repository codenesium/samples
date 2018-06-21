using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetStoreNS.Api.DataAccess
{
        public class BreedRepository : AbstractBreedRepository, IBreedRepository
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
    <Hash>8c28e091ee956fe62f42ef33bb11eabf</Hash>
</Codenesium>*/