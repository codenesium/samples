using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class FamilyService: AbstractFamilyService, IFamilyService
        {
                public FamilyService(
                        ILogger<FamilyRepository> logger,
                        IFamilyRepository familyRepository,
                        IApiFamilyRequestModelValidator familyModelValidator,
                        IBOLFamilyMapper bolfamilyMapper,
                        IDALFamilyMapper dalfamilyMapper)
                        : base(logger,
                               familyRepository,
                               familyModelValidator,
                               bolfamilyMapper,
                               dalfamilyMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4f69cef4a72e6d70b67e4e0c47238c86</Hash>
</Codenesium>*/