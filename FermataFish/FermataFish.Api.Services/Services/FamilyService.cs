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
                        IDALFamilyMapper dalfamilyMapper
                        ,
                        IBOLStudentMapper bolStudentMapper,
                        IDALStudentMapper dalStudentMapper
                        ,
                        IBOLStudentXFamilyMapper bolStudentXFamilyMapper,
                        IDALStudentXFamilyMapper dalStudentXFamilyMapper

                        )
                        : base(logger,
                               familyRepository,
                               familyModelValidator,
                               bolfamilyMapper,
                               dalfamilyMapper
                               ,
                               bolStudentMapper,
                               dalStudentMapper
                               ,
                               bolStudentXFamilyMapper,
                               dalStudentXFamilyMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>eb8aca6ba93f7749870d9b7dd09aadb6</Hash>
</Codenesium>*/