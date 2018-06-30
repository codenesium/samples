using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class PetRepository : AbstractPetRepository, IPetRepository
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
    <Hash>01861365e9542916a5c93ec1009192f4</Hash>
</Codenesium>*/