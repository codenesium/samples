using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class FamilyRepository: AbstractFamilyRepository, IFamilyRepository
        {
                public FamilyRepository(
                        ILogger<FamilyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fd89c56637184c553360b53615505067</Hash>
</Codenesium>*/