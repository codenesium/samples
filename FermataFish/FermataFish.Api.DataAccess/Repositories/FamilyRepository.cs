using Codenesium.DataConversionExtensions;
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
    <Hash>8be502ec5443c34a4d6d4ff4eeb6b5d8</Hash>
</Codenesium>*/