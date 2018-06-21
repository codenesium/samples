using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public class PetRepository : AbstractPetRepository, IPetRepository
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
    <Hash>824cf729c58c2e5d76986f5b86a7d097</Hash>
</Codenesium>*/