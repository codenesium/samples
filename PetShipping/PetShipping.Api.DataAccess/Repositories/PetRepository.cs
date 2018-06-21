using Codenesium.DataConversionExtensions;
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
    <Hash>915cb247cebc46d1c4af359923b207c9</Hash>
</Codenesium>*/