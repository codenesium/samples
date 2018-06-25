using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class FamilyRepository : AbstractFamilyRepository, IFamilyRepository
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
    <Hash>f3bdd597d40f34735e9885de2c9188b8</Hash>
</Codenesium>*/