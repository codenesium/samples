using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace PetShippingNS.Api.DataAccess
{
        public partial class BreedRepository : AbstractBreedRepository, IBreedRepository
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
    <Hash>373425b39ad776adf6f1bcbf5e898100</Hash>
</Codenesium>*/