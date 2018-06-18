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
                        ILogger<IFamilyRepository> logger,
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
    <Hash>1b744cef2b96064076ebc7351b2a9160</Hash>
</Codenesium>*/