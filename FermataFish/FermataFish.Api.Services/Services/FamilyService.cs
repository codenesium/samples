using Codenesium.DataConversionExtensions.AspNetCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Services
{
        public class FamilyService : AbstractFamilyService, IFamilyService
        {
                public FamilyService(
                        ILogger<IFamilyRepository> logger,
                        IFamilyRepository familyRepository,
                        IApiFamilyRequestModelValidator familyModelValidator,
                        IBOLFamilyMapper bolfamilyMapper,
                        IDALFamilyMapper dalfamilyMapper,
                        IBOLStudentMapper bolStudentMapper,
                        IDALStudentMapper dalStudentMapper,
                        IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
                        IDALStudentXFamilyMapper dalStudentXFamilyMapper
                        )
                        : base(logger,
                               familyRepository,
                               familyModelValidator,
                               bolfamilyMapper,
                               dalfamilyMapper,
                               bolStudentMapper,
                               dalStudentMapper,
                               bolStudentXFamilyMapper,
                               dalStudentXFamilyMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0b9025ee3d2ea524dd996c4a140022ef</Hash>
</Codenesium>*/