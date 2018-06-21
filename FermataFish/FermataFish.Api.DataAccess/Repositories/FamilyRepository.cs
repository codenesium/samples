using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class FamilyRepository : AbstractFamilyRepository, IFamilyRepository
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
    <Hash>35d2ce7f436cd8477c6595794dec149a</Hash>
</Codenesium>*/